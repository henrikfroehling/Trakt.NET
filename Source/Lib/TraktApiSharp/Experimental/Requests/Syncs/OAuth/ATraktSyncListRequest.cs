namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Get;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSyncListRequest<TItem> : ATraktListGetRequest<TItem>
    {
        internal ATraktSyncListRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
