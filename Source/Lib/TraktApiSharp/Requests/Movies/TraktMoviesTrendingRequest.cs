namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    internal sealed class TraktMoviesTrendingRequest : ATraktMoviesRequest<TraktTrendingMovie>
    {
        public override string UriTemplate => "movies/trending{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
