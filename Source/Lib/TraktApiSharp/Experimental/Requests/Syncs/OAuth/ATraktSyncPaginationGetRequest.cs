namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Get;
    using Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal abstract class ATraktSyncPaginationGetRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktExtendedInfo
    {
        internal ATraktSyncPaginationGetRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public TraktExtendedInfo ExtendedInfo { get; set; }
    }
}
