namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Post;
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal class TraktSyncWatchlistRemoveRequest : TraktPostRequest<TraktSyncWatchlistRemovePostResponse, TraktSyncWatchlistRemovePostResponse, TraktSyncWatchlistPost>
    {
        internal TraktSyncWatchlistRemoveRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "sync/watchlist/remove";
    }
}
