namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;

    internal sealed class TraktMoviesMostWatchedRequest// : ATraktMoviesMostPWCRequest<TraktMostWatchedMovie>
    {
        internal TraktMoviesMostWatchedRequest(TraktClient client)  { }

        public string UriTemplate => "movies/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";
    }
}
