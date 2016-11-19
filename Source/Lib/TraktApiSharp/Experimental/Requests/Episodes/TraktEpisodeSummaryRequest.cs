namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Base.Get;
    using Objects.Get.Shows.Episodes;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktEpisodeSummaryRequest : ATraktSingleItemGetByIdRequest<TraktEpisode>
    {
        internal TraktEpisodeSummaryRequest(TraktClient client) : base(client) { }

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
