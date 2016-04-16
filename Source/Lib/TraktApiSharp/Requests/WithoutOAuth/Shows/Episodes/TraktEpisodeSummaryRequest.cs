namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Shows.Episodes;

    internal class TraktEpisodeSummaryRequest : TraktGetByIdEpisodeRequest<TraktEpisode, TraktEpisode>
    {
        internal TraktEpisodeSummaryRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        protected override bool IsListResult => false;
    }
}
