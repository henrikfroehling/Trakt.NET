namespace TraktApiSharp.Requests.Movies
{
    using Objects.Basic;

    internal sealed class TraktMovieRatingsRequest : ATraktMovieRequest<ITraktRating>
    {
        public override string UriTemplate => "movies/{id}/ratings";
    }
}
