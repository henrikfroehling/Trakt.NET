namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowsMostWatchedRequest : ATraktShowsMostPWCRequest<TraktMostWatchedShow>
    {
        public TraktShowsMostWatchedRequest(TraktClient client) : base(client) { }

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
