namespace TraktApiSharp.Requests.Seasons
{
    using Objects.Basic;

    internal sealed class TraktSeasonRatingsRequest : ATraktSeasonRequest<ITraktRating>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/ratings";
    }
}
