namespace TraktApiSharp.Experimental.Responses
{
    using Exceptions;
    using Interfaces.Base;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class TraktPaginationResponse<TContentType> : TraktListResponse<TContentType>, ITraktPaginationResponseHeaders
    {
        public int? ItemCount { get; set; }

        public int? Limit { get; set; }

        public int? Page { get; set; }

        public int? PageCount { get; set; }

        internal TraktPaginationResponse() : base() { }

        internal TraktPaginationResponse(List<TContentType> value) { }

        internal TraktPaginationResponse(TraktException exception)  { }

        public static explicit operator List<TContentType>(TraktPaginationResponse<TContentType> response) => response.Value.ToList();

        public static implicit operator TraktPaginationResponse<TContentType>(List<TContentType> value) => new TraktPaginationResponse<TContentType>(value);
    }
}
