namespace TraktApiSharp.Requests.Shows.Seasons
{
    using Objects.Shows.Seasons;

    internal class TraktSeasonStatisticsRequest : TraktGetByIdSeasonRequest<TraktSeasonStatistics, TraktSeasonStatistics>
    {
        internal TraktSeasonStatisticsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/stats";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        protected override bool IsListResult => false;
    }
}
