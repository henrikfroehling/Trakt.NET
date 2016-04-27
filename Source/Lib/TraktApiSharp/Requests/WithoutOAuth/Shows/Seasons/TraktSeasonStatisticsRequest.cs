namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Get.Shows.Seasons;

    internal class TraktSeasonStatisticsRequest : TraktGetByIdSeasonRequest<TraktSeasonStatistics, TraktSeasonStatistics>
    {
        internal TraktSeasonStatisticsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/stats";

        protected override bool IsListResult => false;
    }
}
