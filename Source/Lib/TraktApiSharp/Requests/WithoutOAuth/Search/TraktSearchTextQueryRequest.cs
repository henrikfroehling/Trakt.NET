namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchTextQueryRequest : TraktSearchRequest<TraktSearchResult>
    {
        internal TraktSearchTextQueryRequest(TraktClient client) : base(client) { }

        internal TraktSearchResultType ResultTypes { get; set; }

        internal TraktSearchField SearchFields { get; set; }

        internal string Query { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("type", ResultTypes.UriName);
            uriParams.Add("query", Query);

            if (SearchFields != null && SearchFields != TraktSearchField.Unspecified)
                uriParams.Add("fields", SearchFields.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,extended,page,limit}";
    }
}
