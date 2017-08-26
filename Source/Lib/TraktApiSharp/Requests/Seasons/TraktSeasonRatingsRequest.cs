namespace TraktApiSharp.Requests.Seasons
{
    using Objects.Basic;

    internal sealed class TraktSeasonRatingsRequest : ASeasonRequest<ITraktRating>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/ratings";
    }
}
