namespace TraktApiSharp.Experimental.Requests.Syncs.OAuth
{
    using Objects.Get.Watched;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSyncWatchedShowsRequest : ATraktSyncListRequest<TraktWatchedShow>
    {
        internal TraktSyncWatchedShowsRequest(TraktClient client) : base(client) { }

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
