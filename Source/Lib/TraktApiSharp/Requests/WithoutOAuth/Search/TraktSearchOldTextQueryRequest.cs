namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchOldTextQueryRequest : TraktSearchRequest<TraktSearchResult>
    {
        internal TraktSearchOldTextQueryRequest(TraktClient client) : base(client) { }

        internal string Query { get; set; }

        internal TraktSearchResultType Type { get; set; }

        internal int? Year { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("query", Query);

            if (Type != null && Type != TraktSearchResultType.Unspecified)
                uriParams.Add("type", Type.UriName);

            if (Year.HasValue)
                uriParams.Add("year", Year.Value.ToString());

            return uriParams;
        }

        protected override string UriTemplate => "search{?query,type,year,page,limit}";
    }
}
