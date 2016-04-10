namespace TraktApiSharp.Requests.Shows.Seasons
{
    using Objects;
    using Objects.Shows.Episodes;

    internal class TraktSeasonSingleRequest : TraktGetByIdSeasonRequest<TraktListResult<TraktEpisode>, TraktEpisode>
    {
        internal TraktSeasonSingleRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        protected override bool IsListResult => true;
    }
}
