namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Get;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSyncListGetRequest<TItem> : ATraktListGetRequest<TItem>
    {
        internal ATraktSyncListGetRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
