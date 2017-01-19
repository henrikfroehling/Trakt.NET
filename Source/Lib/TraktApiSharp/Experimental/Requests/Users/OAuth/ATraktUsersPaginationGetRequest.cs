namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktUsersPaginationGetRequest<TItem> : ITraktSupportsExtendedInfo
    {
        internal ATraktUsersPaginationGetRequest(TraktClient client) {}

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;
    }
}
