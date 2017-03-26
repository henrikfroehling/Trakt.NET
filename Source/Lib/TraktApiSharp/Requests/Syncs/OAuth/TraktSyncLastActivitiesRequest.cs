namespace TraktApiSharp.Requests.Syncs.OAuth
{
    using Objects.Get.Syncs.Activities.Implementations;

    internal sealed class TraktSyncLastActivitiesRequest : ATraktSyncGetRequest<TraktSyncLastActivities>
    {
        public override string UriTemplate => "sync/last_activities";
    }
}
