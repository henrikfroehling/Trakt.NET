namespace TraktApiSharp.Requests.Seasons
{
    using Objects.Basic;

    internal sealed class TraktSeasonStatisticsRequest : ASeasonRequest<ITraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
