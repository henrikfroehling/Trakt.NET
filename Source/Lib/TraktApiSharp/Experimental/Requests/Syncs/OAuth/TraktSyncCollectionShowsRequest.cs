namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.Collection;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncCollectionShowsRequest : ATraktSyncListRequest<TraktCollectionShow>
    {
        internal TraktSyncCollectionShowsRequest(TraktClient client) : base(client) { }

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
