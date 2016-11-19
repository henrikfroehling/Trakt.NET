namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Objects.Get.Shows.Episodes;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonSingleRequest : ATraktListGetByIdRequest<TraktEpisode>
    {
        public TraktSeasonSingleRequest(TraktClient client) : base(client) { }

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
