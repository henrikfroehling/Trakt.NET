namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Get.Shows.Episodes;

    internal class TraktEpisodeStatisticsRequest : TraktGetByIdEpisodeRequest<TraktEpisodeStatistics, TraktEpisodeStatistics>
    {
        internal TraktEpisodeStatisticsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/stats";
    }
}
