namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.Watchlist;
    using System;

    internal sealed class TraktSyncWatchlistRequest : ATraktSyncPaginationRequest<TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
