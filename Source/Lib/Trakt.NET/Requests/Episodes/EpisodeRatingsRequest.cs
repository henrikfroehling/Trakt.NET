namespace TraktNet.Requests.Episodes
{
    using Objects.Basic;

    internal sealed class EpisodeRatingsRequest : AEpisodeRequest<ITraktRating>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/ratings";
    }
}
