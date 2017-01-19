namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;

    internal sealed class TraktMoviesMostCollectedRequest : ATraktMoviesMostPWCRequest<TraktMostCollectedMovie>
    {
        internal TraktMoviesMostCollectedRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "movies/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";
    }
}
