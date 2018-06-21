namespace TraktNet.Requests.Seasons
{
    using Objects.Basic;

    internal sealed class SeasonStatisticsRequest : ASeasonRequest<ITraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
