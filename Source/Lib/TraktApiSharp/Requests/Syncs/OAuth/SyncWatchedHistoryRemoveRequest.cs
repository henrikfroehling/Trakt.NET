namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.History.Implementations;
    using Objects.Post.Syncs.History.Responses;

    internal sealed class SyncWatchedHistoryRemoveRequest : ASyncPostRequest<ITraktSyncHistoryRemovePostResponse, TraktSyncHistoryRemovePost>
    {
        public override string UriTemplate => "sync/history/remove";
    }
}
