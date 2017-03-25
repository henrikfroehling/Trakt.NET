namespace TraktApiSharp.Requests.Movies
{
    using Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;

    internal sealed class TraktMovieRatingsRequest : ATraktMovieRequest<TraktRating>
    {
        public override string UriTemplate => "movies/{id}/ratings";
    }
}
