namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Post.Syncs.Watchlist;
    using Objects.Post.Syncs.Watchlist.Responses;
    using System;

    internal sealed class TraktSyncWatchlistAddRequest : ATraktSyncSingleItemPostRequest<TraktSyncWatchlistPostResponse, TraktSyncWatchlistPost>
    {
        internal TraktSyncWatchlistAddRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
