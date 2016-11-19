namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSeasonSingleRequest : ATraktListGetByIdRequest<TraktEpisode>, ITraktObjectRequest, ITraktExtendedInfo
    {
        internal TraktSeasonSingleRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        public override string UriTemplate => "shows/{id}/seasons/{season}{?extended}";
    }
}
