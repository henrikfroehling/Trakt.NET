namespace TraktApiSharp.Experimental.Requests.Shows.OAuth
{
    using Objects.Get.Shows;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowWatchedProgressRequest : ATraktShowProgressRequest<TraktShowWatchedProgress>
    {
        public TraktShowWatchedProgressRequest(TraktClient client) : base(client) { }

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
