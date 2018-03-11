namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.History.Implementations;
    using Objects.Post.Syncs.History.Responses;

    internal sealed class SyncWatchedHistoryAddRequest : ASyncPostRequest<ITraktSyncHistoryPostResponse, TraktSyncHistoryPost>
    {
        public override string UriTemplate => "sync/history";
    }
}
