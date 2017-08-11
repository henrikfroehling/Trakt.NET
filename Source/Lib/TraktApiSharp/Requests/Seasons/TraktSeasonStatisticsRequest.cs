namespace TraktApiSharp.Requests.Seasons
{
    using Objects.Basic;

    internal sealed class TraktSeasonStatisticsRequest : ATraktSeasonRequest<ITraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
