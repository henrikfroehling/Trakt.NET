namespace TraktApiSharp.Requests.Episodes
{
    using Objects.Basic;

    internal sealed class TraktEpisodeRatingsRequest : ATraktEpisodeRequest<TraktRating>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/ratings";
    }
}
