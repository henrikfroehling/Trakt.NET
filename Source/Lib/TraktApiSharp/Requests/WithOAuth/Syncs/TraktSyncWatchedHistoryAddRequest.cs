namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Post;
    using Objects.Post.Syncs.History;
    using Objects.Post.Syncs.History.Responses;

    internal class TraktSyncWatchedHistoryAddRequest : TraktPostRequest<TraktSyncHistoryPostResponse, TraktSyncHistoryPostResponse, TraktSyncHistoryPost>
    {
        internal TraktSyncWatchedHistoryAddRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "sync/history";
    }
}
