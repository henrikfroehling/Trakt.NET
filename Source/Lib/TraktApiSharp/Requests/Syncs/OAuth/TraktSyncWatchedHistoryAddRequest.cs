namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;

    internal sealed class TraktSyncWatchedHistoryAddRequest : ATraktSyncPostRequest<TraktSyncHistoryPostResponse, TraktSyncHistoryPost>
    {
        public override string UriTemplate => "sync/history";
    }
}
