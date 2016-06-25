namespace TraktApiSharp.Requests.WithOAuth.Syncs
{
    using Base.Get;
    using Objects.Get.Syncs.Activities;

    internal class TraktSyncLastActivitiesRequest : TraktGetRequest<TraktSyncLastActivities, TraktSyncLastActivities>
    {
        internal TraktSyncLastActivitiesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override string UriTemplate => "sync/last_activities";
    }
}
