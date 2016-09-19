namespace TraktApiSharp.Experimental.Responses
{
    using Exceptions;
    using System.Collections;
    using System.Collections.Generic;

    public class TraktListResponse<TContentType> : ATraktResponse<List<TContentType>>, ITraktResponseHeaders, IEnumerable<TContentType>
    {
        public string SortBy { get; set; }

        public string SortHow { get; set; }

        public int? UserCount { get; set; }

        internal TraktListResponse() : base() { }

        internal TraktListResponse(List<TContentType> value) : base(value) { }

        internal TraktListResponse(TraktException exception) : base(exception) { }

        public static explicit operator List<TContentType>(TraktListResponse<TContentType> response) => response.Value;

        public static implicit operator TraktListResponse<TContentType>(List<TContentType> value) => new TraktListResponse<TContentType>(value);

        public IEnumerator<TContentType> GetEnumerator() => Value.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
