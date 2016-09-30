namespace TraktApiSharp.Experimental.Requests.Search
{
    using TraktApiSharp.Requests;

    internal sealed class TraktSearchTextQueryRequest : ATraktSearchRequest
    {
        public TraktSearchTextQueryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,extended,page,limit}";
    }
}
