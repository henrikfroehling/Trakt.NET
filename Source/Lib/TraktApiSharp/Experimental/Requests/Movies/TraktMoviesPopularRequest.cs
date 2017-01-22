namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class TraktMoviesPopularRequest// : ATraktMoviesRequest<TraktMovie>
    {
        internal TraktMoviesPopularRequest(TraktClient client) { }

        public string UriTemplate => "movies/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";
    }
}
