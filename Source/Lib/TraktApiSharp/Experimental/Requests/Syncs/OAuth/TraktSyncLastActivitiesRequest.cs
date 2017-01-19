namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.Syncs.Activities;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncLastActivitiesRequest
    {
        internal TraktSyncLastActivitiesRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public string UriTemplate => "sync/last_activities";
    }
}
