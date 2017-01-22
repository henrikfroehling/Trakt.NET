namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;

    internal sealed class TraktMoviesMostAnticipatedRequest// : ATraktMoviesRequest<TraktMostAnticipatedMovie>
    {
        internal TraktMoviesMostAnticipatedRequest(TraktClient client) { }

        public string UriTemplate => "movies/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";
    }
}
