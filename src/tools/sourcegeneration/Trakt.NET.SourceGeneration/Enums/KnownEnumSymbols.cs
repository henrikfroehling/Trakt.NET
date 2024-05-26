using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Enums
{
    public sealed class KnownEnumSymbols(Compilation compilation) : KnownSymbols(compilation)
    {
        private OptionalValue<INamedTypeSymbol?> _systemFlagsAttributeType;
        private OptionalValue<INamedTypeSymbol?> _traktEnumAttributeType;
        private OptionalValue<INamedTypeSymbol?> _traktEnumMemberAttributeType;
        private OptionalValue<INamedTypeSymbol?> _traktParameterEnumAttributeType;

        public INamedTypeSymbol? SystemFlagsAttributeType
            => GetOrResolveType(EnumConstants.FullSystemFlagsAttributeName, ref _systemFlagsAttributeType);

        public INamedTypeSymbol? TraktEnumAttributeType
            => GetOrResolveType(EnumConstants.FullTraktEnumAttributeName, ref _traktEnumAttributeType);

        public INamedTypeSymbol? TraktEnumMemberAttributeType
            => GetOrResolveType(EnumConstants.FullTraktEnumMemberJsonValueAttributeName, ref _traktEnumMemberAttributeType);

        public INamedTypeSymbol? TraktParameterEnumAttributeType
            => GetOrResolveType(EnumConstants.FullTraktParameterEnumAttributeName, ref _traktParameterEnumAttributeType);
    }
}
