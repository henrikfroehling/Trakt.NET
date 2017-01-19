namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktSyncListGetRequest<TItem>
    {
        internal ATraktSyncListGetRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}
