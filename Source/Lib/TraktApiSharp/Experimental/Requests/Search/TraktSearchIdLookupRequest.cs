namespace TraktApiSharp.Experimental.Requests.Search
{
    using Enums;

    internal sealed class TraktSearchIdLookupRequest : ATraktSearchRequest
    {
        public TraktSearchIdLookupRequest(TraktClient client) : base(client) { }

        internal TraktSearchIdType IdType { get; set; }

        public override string UriTemplate => "search/{id_type}/{id}{?type,extended,page,limit}";
    }
}
