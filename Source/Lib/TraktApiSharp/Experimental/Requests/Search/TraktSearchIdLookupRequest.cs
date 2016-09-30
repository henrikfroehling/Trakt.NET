namespace TraktApiSharp.Experimental.Requests.Search
{
    internal sealed class TraktSearchIdLookupRequest : ATraktSearchRequest
    {
        public TraktSearchIdLookupRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "search/{id_type}/{id}{?type,extended,page,limit}";
    }
}
