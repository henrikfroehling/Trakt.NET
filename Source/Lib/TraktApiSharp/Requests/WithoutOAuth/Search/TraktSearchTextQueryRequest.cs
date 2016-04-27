namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchTextQueryRequest : TraktGetRequest<TraktPaginationListResult<TraktSearchResult>, TraktSearchResult>
    {
        public TraktSearchTextQueryRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        internal string Query { get; set; }

        internal TraktSearchResultType Type { get; set; }

        internal int? Year { get; set; }

        protected override bool IsSearchRequest => true;

        protected override bool IsListResult => true;

        protected override bool SupportsPagination => true;

        protected override string UriTemplate => "search";

        protected override IEnumerable<KeyValuePair<string, string>> GetSearchOptionParameters()
        {
            var searchParams = new Dictionary<string, string>();

            searchParams["query"] = Query;

            if (Type != TraktSearchResultType.Unspecified)
                searchParams["type"] = Type.AsString();

            if (Year.HasValue)
                searchParams["year"] = Year.Value.ToString();

            return searchParams;
        }
    }
}
