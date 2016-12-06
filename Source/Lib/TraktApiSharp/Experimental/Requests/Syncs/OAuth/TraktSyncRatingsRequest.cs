namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.Ratings;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncRatingsRequest : ATraktSyncListRequest<TraktRatingsItem>
    {
        internal TraktSyncRatingsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
