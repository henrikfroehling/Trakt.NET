namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;

    internal sealed class TraktSyncWatchedHistoryRemoveRequest : ASyncPostRequest<ITraktSyncHistoryRemovePostResponse, TraktSyncHistoryRemovePost>
    {
        public override string UriTemplate => "sync/history/remove";
    }
}
