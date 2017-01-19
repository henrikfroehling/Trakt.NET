namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    internal sealed class TraktSyncCollectionAddRequest
    {
        internal TraktSyncCollectionAddRequest(TraktClient client) { }

        public string UriTemplate => "sync/collection";
    }
}
