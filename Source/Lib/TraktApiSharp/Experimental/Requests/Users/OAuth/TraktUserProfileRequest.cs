namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Interfaces;
    using Objects.Get.Users;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktUserProfileRequest : ATraktUsersSingleItemGetRequest<TraktUser>, ITraktExtendedInfo
    {
        internal TraktUserProfileRequest(TraktClient client) : base(client) {}

        internal string Username { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;

        public override string UriTemplate => "users/{username}{?extended}";
    }
}
