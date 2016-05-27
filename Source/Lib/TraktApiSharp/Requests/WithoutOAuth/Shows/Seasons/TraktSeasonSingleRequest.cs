namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Basic;
    using Objects.Get.Shows.Episodes;

    internal class TraktSeasonSingleRequest : TraktGetByIdSeasonRequest<TraktListResult<TraktEpisode>, TraktEpisode>
    {
        internal TraktSeasonSingleRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}{?extended}";

        protected override bool IsListResult => true;
    }
}
