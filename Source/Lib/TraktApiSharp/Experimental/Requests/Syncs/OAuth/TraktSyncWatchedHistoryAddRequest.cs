namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;

    internal sealed class TraktSyncWatchedHistoryAddRequest : ATraktSyncSingleItemPostRequest<TraktSyncHistoryPostResponse, TraktSyncHistoryPost>
    {
        internal TraktSyncWatchedHistoryAddRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "sync/history";
    }
}
