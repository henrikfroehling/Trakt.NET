namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class TraktMoviesMostWatchedRequest : ATraktMoviesMostPWCRequest<TraktMostPWCMovie>
    {
        public override string UriTemplate => "movies/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
