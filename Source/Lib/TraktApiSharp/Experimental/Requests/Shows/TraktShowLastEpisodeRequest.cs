namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows.Episodes;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowLastEpisodeRequest : ATraktSingleItemGetByIdRequest<TraktEpisode>
    {
        public TraktShowLastEpisodeRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
