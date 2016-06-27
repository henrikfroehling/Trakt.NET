namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Basic;

    internal class TraktEpisodeStatisticsRequest : TraktGetByIdEpisodeRequest<TraktStatistics, TraktStatistics>
    {
        internal TraktEpisodeStatisticsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/stats";
    }
}
