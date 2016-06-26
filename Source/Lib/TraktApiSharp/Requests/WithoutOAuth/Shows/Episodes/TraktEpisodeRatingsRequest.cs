namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Basic;

    internal class TraktEpisodeRatingsRequest : TraktGetByIdEpisodeRequest<TraktRating, TraktRating>
    {
        internal TraktEpisodeRatingsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/ratings";
    }
}
