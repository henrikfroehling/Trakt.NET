namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Objects.Get.Watchlist;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserWatchlistRequest : ATraktUsersPaginationGetRequest<TraktWatchlistItem>
    {
        internal TraktUserWatchlistRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/watchlist{/type}{?extended,page,limit}";
    }
}
