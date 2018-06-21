namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;

    internal sealed class SyncWatchedHistoryAddRequest : ASyncPostRequest<ITraktSyncHistoryPostResponse, ITraktSyncHistoryPost>
    {
        public override string UriTemplate => "sync/history";
    }
}
