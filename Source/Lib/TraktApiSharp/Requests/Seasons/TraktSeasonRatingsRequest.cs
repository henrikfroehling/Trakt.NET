namespace TraktApiSharp.Requests.Seasons
{
    using Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;

    internal sealed class TraktSeasonRatingsRequest : ATraktSeasonRequest<TraktRating>
    {
        public override string UriTemplate => "shows/{id}/seasons/{season}/ratings";
    }
}
