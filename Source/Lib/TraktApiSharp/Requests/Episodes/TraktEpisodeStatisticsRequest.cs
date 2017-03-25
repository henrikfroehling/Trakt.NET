namespace TraktApiSharp.Requests.Episodes
{
    using Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;

    internal sealed class TraktEpisodeStatisticsRequest : ATraktEpisodeRequest<TraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/stats";
    }
}
