namespace TraktApiSharp.Experimental.Requests.Search
{
    using Enums;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSearchTextQueryRequest : ATraktSearchRequest, ITraktFilterable
    {
        public TraktSearchTextQueryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktCommonFilter Filter { get; set; }

        internal TraktSearchField SearchFields { get; set; }

        public override string UriTemplate => "search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,extended,page,limit}";
    }
}
