namespace TraktApiSharp.Experimental.Responses
{
    using Exceptions;

    public sealed class TraktResponse<TContentType> : ATraktResponse<TContentType>, ITraktResponseHeaders
    {
        public string SortBy { get; set; }

        public string SortHow { get; set; }

        public int? UserCount { get; set; }

        internal TraktResponse() : base() { }

        internal TraktResponse(TContentType value) : base(value) { }

        internal TraktResponse(TraktException exception) : base(exception) { }

        public static explicit operator TContentType(TraktResponse<TContentType> response) => response.Value;

        public static implicit operator TraktResponse<TContentType>(TContentType value) => new TraktResponse<TContentType>(value);
    }
}
