namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Watchlist;
    using System.Collections.Generic;

    internal sealed class TraktUserWatchlistRequest : ATraktUsersPaginationGetRequest<TraktWatchlistItem>
    {
        internal TraktUserWatchlistRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            uriParams.Add("username", Username);

            if (Type != null && Type != TraktSyncItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public string UriTemplate => "users/{username}/watchlist{/type}{?extended,page,limit}";
    }
}
