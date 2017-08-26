namespace TraktApiSharp.Requests.Seasons
{
    using Objects.Basic;

    internal sealed class SeasonRatingsRequest : ASeasonRequest<ITraktRating>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/ratings";
    }
}
