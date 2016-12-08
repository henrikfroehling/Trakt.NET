namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.Watchlist;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncWatchlistRequest : ATraktSyncPaginationRequest<TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
