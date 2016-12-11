namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;

    internal sealed class TraktSyncWatchedHistoryRemoveRequest : ATraktSyncSingleItemPostRequest<TraktSyncHistoryRemovePostResponse, TraktSyncHistoryRemovePost>
    {
        internal TraktSyncWatchedHistoryRemoveRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "sync/history/remove";
    }
}
