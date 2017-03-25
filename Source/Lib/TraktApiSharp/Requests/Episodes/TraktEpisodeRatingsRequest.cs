namespace TraktApiSharp.Requests.Episodes
{
    using Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;

    internal sealed class TraktEpisodeRatingsRequest : ATraktEpisodeRequest<TraktRating>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/ratings";
    }
}
