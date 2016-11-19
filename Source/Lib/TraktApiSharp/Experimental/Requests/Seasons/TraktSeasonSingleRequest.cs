namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonSingleRequest : ATraktListGetByIdRequest<TraktEpisode>, ITraktObjectRequest
    {
        internal TraktSeasonSingleRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        public override string UriTemplate => "shows/{id}/seasons/{season}{?extended}";
    }
}
