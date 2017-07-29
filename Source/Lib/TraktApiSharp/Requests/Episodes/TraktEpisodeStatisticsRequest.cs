namespace TraktApiSharp.Requests.Episodes
{
    using Objects.Basic;

    internal sealed class TraktEpisodeStatisticsRequest : ATraktEpisodeRequest<ITraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/stats";
    }
}
