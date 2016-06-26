namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Basic;

    internal class TraktSeasonStatisticsRequest : TraktGetByIdSeasonRequest<TraktStatistics, TraktStatistics>
    {
        internal TraktSeasonStatisticsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/stats";
    }
}
