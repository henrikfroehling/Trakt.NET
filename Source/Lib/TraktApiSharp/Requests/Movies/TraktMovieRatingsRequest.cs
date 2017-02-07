namespace TraktApiSharp.Requests.Movies
{
    using Objects.Basic;

    internal sealed class TraktMovieRatingsRequest : ATraktMovieRequest<TraktRating>
    {
        public override string UriTemplate => "movies/{id}/ratings";
    }
}
