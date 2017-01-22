namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Objects.Basic;

    internal sealed class TraktSeasonRatingsRequest : ATraktSeasonRequest<TraktRating>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/ratings";
    }
}
