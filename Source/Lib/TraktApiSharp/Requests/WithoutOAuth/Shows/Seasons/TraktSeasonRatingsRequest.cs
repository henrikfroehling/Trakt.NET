namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Basic;

    internal class TraktSeasonRatingsRequest : TraktGetByIdSeasonRequest<TraktRating, TraktRating>
    {
        internal TraktSeasonRatingsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/ratings";
    }
}
