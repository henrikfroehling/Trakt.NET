namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktUsersListGetRequest<TItem> : ITraktSupportsExtendedInfo
    {
        internal ATraktUsersListGetRequest(TraktClient client) {}

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;
    }
}
