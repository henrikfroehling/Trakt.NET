namespace TraktApiSharp.Experimental.Responses
{
    using Exceptions;
    using System.Collections.Generic;

    public sealed class TraktPaginationResponse<TContentType> : TraktListResponse<TContentType>, ITraktPaginationResponseHeaders
    {
        public int? ItemCount { get; set; }

        public int? Limit { get; set; }

        public int? Page { get; set; }

        public int? PageCount { get; set; }

        internal TraktPaginationResponse() : base() { }

        internal TraktPaginationResponse(List<TContentType> value) : base(value) { }

        internal TraktPaginationResponse(TraktException exception) : base(exception) { }

        public static explicit operator List<TContentType>(TraktPaginationResponse<TContentType> response) => response.Value;

        public static implicit operator TraktPaginationResponse<TContentType>(List<TContentType> value) => new TraktPaginationResponse<TContentType>(value);
    }
}
