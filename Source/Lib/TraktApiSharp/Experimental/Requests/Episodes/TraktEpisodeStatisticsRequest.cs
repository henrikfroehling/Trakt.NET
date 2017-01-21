namespace TraktApiSharp.Experimental.Requests.Episodes
{
    using Objects.Basic;

    internal sealed class TraktEpisodeStatisticsRequest : ATraktEpisodeRequest<TraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/stats";
    }
}
