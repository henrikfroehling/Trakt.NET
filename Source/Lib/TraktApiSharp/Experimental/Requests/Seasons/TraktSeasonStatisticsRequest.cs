namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Objects.Basic;

    internal sealed class TraktSeasonStatisticsRequest : ATraktSeasonRequest<TraktStatistics>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
