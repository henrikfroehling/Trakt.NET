namespace TraktNet.Requests.Syncs.OAuth
{
    using Objects.Get.Syncs.Activities;

    internal sealed class SyncLastActivitiesRequest : ASyncGetRequest<ITraktSyncLastActivities>
    {
        public override string UriTemplate => "sync/last_activities";
    }
}
