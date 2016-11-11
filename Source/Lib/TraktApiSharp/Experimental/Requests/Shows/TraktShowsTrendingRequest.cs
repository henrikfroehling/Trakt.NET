namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowsTrendingRequest : ATraktShowsRequest<TraktTrendingShow>
    {
        public TraktShowsTrendingRequest(TraktClient client) : base(client) { }

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
