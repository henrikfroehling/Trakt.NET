namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies.Common;

    internal sealed class TraktMoviesMostCollectedRequest : ATraktMoviesMostPWCRequest<TraktMostCollectedMovie>
    {
        public override string UriTemplate => "movies/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
