namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Get.Syncs.Activities;

    internal sealed class TraktSyncLastActivitiesRequest : ATraktSyncGetRequest<ITraktSyncLastActivities>
    {
        public override string UriTemplate => "sync/last_activities";
    }
}
