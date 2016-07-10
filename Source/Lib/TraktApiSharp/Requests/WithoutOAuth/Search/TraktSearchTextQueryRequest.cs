namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchTextQueryRequest : TraktSearchRequest<TraktSearchResult>
    {
        public TraktSearchTextQueryRequest(TraktClient client) : base(client) { }

        internal TraktSearchResultType Type { get; set; }

        internal string Query { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("type", Type.AsString());
            uriParams.Add("query", Query);

            return uriParams;
        }

        protected override string UriTemplate => "search/{type}{?query,years,genres,languages,countries,runtimes,ratings,extended,page,limit}";
    }
}
