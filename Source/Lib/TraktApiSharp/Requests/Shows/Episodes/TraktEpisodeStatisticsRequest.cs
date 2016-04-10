namespace TraktApiSharp.Requests.Shows.Episodes
{
    using Objects.Shows.Episodes;

    internal class TraktEpisodeStatisticsRequest : TraktGetByIdEpisodeRequest<TraktEpisodeStatistics, TraktEpisodeStatistics>
    {
        internal TraktEpisodeStatisticsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/stats";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;
    }
}
