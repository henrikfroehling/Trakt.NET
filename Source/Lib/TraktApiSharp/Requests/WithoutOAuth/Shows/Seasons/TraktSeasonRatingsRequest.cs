namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Get.Shows.Seasons;

    internal class TraktSeasonRatingsRequest : TraktGetByIdSeasonRequest<TraktSeasonRating, TraktSeasonRating>
    {
        internal TraktSeasonRatingsRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/ratings";

        protected override bool IsListResult => false;
    }
}
