namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Post;
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;

    internal class TraktSyncWatchlistAddRequest : TraktPostRequest<TraktSyncWatchlistPostResponse, TraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>
    {
        internal TraktSyncWatchlistAddRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "sync/watchlist";
    }
}
