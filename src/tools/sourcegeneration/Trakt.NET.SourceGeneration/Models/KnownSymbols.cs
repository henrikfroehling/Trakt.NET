using Microsoft.CodeAnalysis;

namespace TraktNET.SourceGeneration.Models
{
    public class KnownSymbols(Compilation compilation)
    {
        public Compilation Compilation { get; } = compilation;

        protected INamedTypeSymbol? GetOrResolveType(string fullQualifiedName, ref OptionalValue<INamedTypeSymbol?> symbol)
        {
            if (symbol.HasValue)
                return symbol.Value;

            INamedTypeSymbol? typeSymbol = GetBestTypeByMetadataName(fullQualifiedName);
            symbol = new(typeSymbol);
            return typeSymbol;
        }

        private INamedTypeSymbol? GetBestTypeByMetadataName(string fullQualifiedName)
        {
            INamedTypeSymbol? type = Compilation.GetTypeByMetadataName(fullQualifiedName);
            type ??= Compilation.Assembly.GetTypeByMetadataName(fullQualifiedName);

            if (type == null)
            {
                foreach (IModuleSymbol module in Compilation.Assembly.Modules)
                {
                    foreach (IAssemblySymbol referenceAssembly in module.ReferencedAssemblySymbols)
                    {
                        INamedTypeSymbol? currentType = referenceAssembly.GetTypeByMetadataName(fullQualifiedName);

                        if (currentType == null)
                            continue;

                        switch (GetVisibility(currentType))
                        {
                            case SymbolVisibility.Public:
                            case SymbolVisibility.Internal when referenceAssembly.GivesAccessTo(Compilation.Assembly):
                                break;
                            default:
                                continue;
                        }

                        if (type is object)
                            return null;

                        type = currentType;
                    }
                }
            }

            return type;
        }

        private static SymbolVisibility GetVisibility(ISymbol symbol)
        {
            SymbolVisibility visibility = SymbolVisibility.Public;

            switch (symbol.Kind)
            {
                case SymbolKind.Alias:
                case SymbolKind.TypeParameter:
                    return SymbolVisibility.Private;
                case SymbolKind.Parameter:
                    return GetVisibility(symbol.ContainingSymbol);
            }

            while (symbol != null && symbol.Kind != SymbolKind.Namespace)
            {
                switch (symbol.DeclaredAccessibility)
                {
                    case Accessibility.NotApplicable:
                    case Accessibility.Private:
                        return SymbolVisibility.Private;
                    case Accessibility.Internal:
                    case Accessibility.ProtectedOrInternal:
                        visibility = SymbolVisibility.Internal;
                        break;
                }

                symbol = symbol.ContainingSymbol;
            }

            return visibility;
        }

        private enum SymbolVisibility
        {
            Public = 0,
            Internal = 1,
            Private = 2,
            Friend = Internal
        }
    }
}
