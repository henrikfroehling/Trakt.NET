namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchTextQueryRequest : TraktSearchRequest<TraktSearchResult>
    {
        internal TraktSearchTextQueryRequest(TraktClient client) : base(client) { }

        internal string Query { get; set; }

        internal TraktSearchResultType Type { get; set; }

        internal int? Year { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetCustomExtendedOptionParameters()
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
