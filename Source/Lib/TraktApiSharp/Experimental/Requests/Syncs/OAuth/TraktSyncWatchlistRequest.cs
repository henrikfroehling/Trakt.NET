namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.Watchlist;
    using System.Collections.Generic;

    internal sealed class TraktSyncWatchlistRequest : ATraktSyncPaginationRequest<TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        internal TraktSyncItemType Type { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type != null && Type != TraktSyncItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public override string UriTemplate => "sync/watchlist{/type}{?extended,page,limit}";
    }
}
