namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Post;
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;

    internal class TraktSyncWatchedHistoryRemoveRequest : TraktPostRequest<TraktSyncHistoryRemovePostResponse, TraktSyncHistoryRemovePostResponse, TraktSyncHistoryRemovePost>
    {
        internal TraktSyncWatchedHistoryRemoveRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "sync/history/remove";
    }
}
