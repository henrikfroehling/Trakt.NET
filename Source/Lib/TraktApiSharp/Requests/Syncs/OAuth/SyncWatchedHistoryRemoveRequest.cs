namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;

    internal sealed class SyncWatchedHistoryRemoveRequest : ASyncPostRequest<ITraktSyncHistoryRemovePostResponse, ITraktSyncHistoryRemovePost>
    {
        public override string UriTemplate => "sync/history/remove";
    }
}
