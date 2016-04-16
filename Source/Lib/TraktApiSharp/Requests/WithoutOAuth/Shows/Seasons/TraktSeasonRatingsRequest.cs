namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Shows.Seasons;

    internal class TraktSeasonRatingsRequest : TraktGetByIdSeasonRequest<TraktSeasonRating, TraktSeasonRating>
    {
        internal TraktSeasonRatingsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/ratings";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Seasons;

        protected override bool IsListResult => false;
    }
}
