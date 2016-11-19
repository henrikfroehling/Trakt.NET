namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Base.Get;
    using Objects.Get.Shows.Episodes;
    using TraktApiSharp.Requests;

    internal sealed class TraktSeasonSingleRequest : ATraktListGetByIdRequest<TraktEpisode>
    {
        public TraktSeasonSingleRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/{id}/seasons/{season}{?extended}";
    }
}
