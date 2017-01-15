namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Watchlist;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserWatchlistRequest : ATraktUsersPaginationGetRequest<TraktWatchlistItem>
    {
        internal TraktUserWatchlistRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktSyncItemType Type { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/watchlist{/type}{?extended,page,limit}";
    }
}
