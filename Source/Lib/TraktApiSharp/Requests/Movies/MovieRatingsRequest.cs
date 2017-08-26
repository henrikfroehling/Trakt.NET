namespace TraktApiSharp.Requests.Movies
{
    using Objects.Basic;

    internal sealed class MovieRatingsRequest : AMovieRequest<ITraktRating>
    {
        public override string UriTemplate => "movies/{id}/ratings";
    }
}
