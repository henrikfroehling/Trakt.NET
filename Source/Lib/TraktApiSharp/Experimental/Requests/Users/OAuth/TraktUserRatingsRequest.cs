namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Ratings;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserRatingsRequest : ATraktUsersListGetRequest<TraktRatingsItem>
    {
        internal TraktUserRatingsRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        internal TraktRatingsItemType Type { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}/ratings{/type}{/rating}{?extended}";
    }
}
