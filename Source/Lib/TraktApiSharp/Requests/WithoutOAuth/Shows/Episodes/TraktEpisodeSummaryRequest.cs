namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Get.Shows.Episodes;

    internal class TraktEpisodeSummaryRequest : TraktGetByIdEpisodeRequest<TraktEpisode, TraktEpisode>
    {
        internal TraktEpisodeSummaryRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}";
    }
}
