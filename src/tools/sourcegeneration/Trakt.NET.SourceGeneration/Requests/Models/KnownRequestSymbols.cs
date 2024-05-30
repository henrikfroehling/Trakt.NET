﻿using Microsoft.CodeAnalysis;
using TraktNET.SourceGeneration.Models;

namespace TraktNET.SourceGeneration.Requests
{
    public sealed class KnownRequestSymbols(Compilation compilation) : KnownSymbols(compilation)
    {
        private OptionalValue<INamedTypeSymbol?> _traktOAuthRequirementEnumType;
        private OptionalValue<INamedTypeSymbol?> _traktGetRequestAttributeType;
        private OptionalValue<INamedTypeSymbol?> _traktPostRequestAttributeType;
        private OptionalValue<INamedTypeSymbol?> _traktPutRequestAttributeType;
        private OptionalValue<INamedTypeSymbol?> _traktDeleteRequestAttributeType;

        public INamedTypeSymbol? TraktOAuthRequirementEnumType
            => GetOrResolveType(RequestConstants.FullTraktOAuthRequirementName, ref _traktOAuthRequirementEnumType);

        public INamedTypeSymbol? TraktGetRequestAttributeType
            => GetOrResolveType(RequestConstants.FullTraktGetRequestAttributeName, ref _traktGetRequestAttributeType);

        public INamedTypeSymbol? TraktPostRequestAttributeType
            => GetOrResolveType(RequestConstants.FullTraktPostRequestAttributeName, ref _traktPostRequestAttributeType);

        public INamedTypeSymbol? TraktPutRequestAttributeType
            => GetOrResolveType(RequestConstants.FullTraktPutRequestAttributeName, ref _traktPutRequestAttributeType);

        public INamedTypeSymbol? TraktDeleteRequestAttributeType
            => GetOrResolveType(RequestConstants.FullTraktDeleteRequestAttributeName, ref _traktDeleteRequestAttributeType);
    }
}
