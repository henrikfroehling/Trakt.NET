namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows.Episodes;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowNextEpisodeRequest : ATraktSingleItemGetByIdRequest<TraktEpisode>
    {
        public TraktShowNextEpisodeRequest(TraktClient client) : base(client) { }

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
