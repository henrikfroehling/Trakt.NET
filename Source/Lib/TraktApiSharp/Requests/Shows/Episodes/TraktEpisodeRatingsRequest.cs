namespace TraktApiSharp.Requests.Shows.Episodes
{
    using Objects.Shows.Episodes;

    internal class TraktEpisodeRatingsRequest : TraktGetByIdEpisodeRequest<TraktEpisodeRating, TraktEpisodeRating>
    {
        internal TraktEpisodeRatingsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/ratings";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Episodes;

        protected override bool IsListResult => false;
    }
}
