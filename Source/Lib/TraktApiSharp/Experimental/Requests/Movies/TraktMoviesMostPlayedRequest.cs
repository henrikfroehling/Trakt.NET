namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;

    internal sealed class TraktMoviesMostPlayedRequest //: ATraktMoviesMostPWCRequest<TraktMostPlayedMovie>
    {
        internal TraktMoviesMostPlayedRequest(TraktClient client)  { }

        public string UriTemplate => "movies/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";
    }
}
