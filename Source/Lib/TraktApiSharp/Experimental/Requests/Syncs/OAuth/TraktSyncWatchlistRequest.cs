namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Enums;
    using Objects.Get.Watchlist;
    using System.Collections.Generic;

    internal sealed class TraktSyncWatchlistRequest : ATraktSyncPaginationGetRequest<TraktWatchlistItem>
    {
        internal TraktSyncWatchlistRequest(TraktClient client) : base(client) { }

        internal TraktSyncItemType Type { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Type != null && Type != TraktSyncItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public string UriTemplate => "sync/watchlist{/type}{?extended,page,limit}";
    }
}
