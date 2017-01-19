namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktUsersPaginationGetRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktSupportsExtendedInfo
    {
        internal ATraktUsersPaginationGetRequest(TraktClient client) : base(client) {}

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Optional;
    }
}
