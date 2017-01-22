namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;

    internal sealed class TraktMoviesTrendingRequest// : ATraktMoviesRequest<TraktTrendingMovie>
    {
        internal TraktMoviesTrendingRequest(TraktClient client)  { }

        public string UriTemplate => "movies/trending{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";
    }
}
