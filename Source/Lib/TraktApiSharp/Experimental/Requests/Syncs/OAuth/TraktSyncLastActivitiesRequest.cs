namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Base.Get;
    using Objects.Get.Syncs.Activities;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncLastActivitiesRequest : ATraktSingleItemGetRequest<TraktSyncLastActivities>
    {
        internal TraktSyncLastActivitiesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
