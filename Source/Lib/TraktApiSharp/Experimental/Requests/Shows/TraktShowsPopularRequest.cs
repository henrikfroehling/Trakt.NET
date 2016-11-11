namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowsPopularRequest : ATraktShowsRequest<TraktShow>
    {
        public TraktShowsPopularRequest(TraktClient client) : base(client) { }

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
