namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class TraktMoviesTrendingRequest : ATraktMoviesRequest<TraktTrendingMovie>
    {
        public override string UriTemplate => "movies/trending{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
