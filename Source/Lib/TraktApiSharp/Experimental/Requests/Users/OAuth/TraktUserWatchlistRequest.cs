namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Watchlist;
    using System;

    internal sealed class TraktUserWatchlistRequest : ATraktUsersPaginationGetRequest<TraktWatchlistItem>
    {
        internal TraktUserWatchlistRequest(TraktClient client) : base(client) {}

        public override string UriTemplate => throw new NotImplementedException();
    }
}
