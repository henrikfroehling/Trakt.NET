namespace TraktApiSharp.Requests.Seasons
{
    using Objects.Basic.Implementations;

    internal sealed class TraktSeasonStatisticsRequest : ATraktSeasonRequest<TraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
