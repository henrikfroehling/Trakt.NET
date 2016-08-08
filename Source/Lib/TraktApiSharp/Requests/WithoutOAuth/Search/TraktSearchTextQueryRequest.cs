namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchTextQueryRequest : TraktSearchRequest<TraktSearchResult>
    {
        internal TraktSearchTextQueryRequest(TraktClient client) : base(client) { }

        internal TraktSearchResultType ResultType { get; set; }

        internal string Query { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("type", ResultType.UriName);
            uriParams.Add("query", Query);

            return uriParams;
        }

        protected override string UriTemplate => "search/{type}{?query,years,genres,languages,countries,runtimes,ratings,extended,page,limit}";
    }
}
