namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Interfaces;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktUserWatchingRequest : ATraktUsersSingleItemGetRequest<TraktUserWatchingItem>, ITraktExtendedInfo
    {
        internal TraktUserWatchingRequest(TraktClient client) : base(client) {}

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "users/{username}/watching{?extended}";
    }
}
