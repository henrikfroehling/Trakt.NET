namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies.Common;

    internal sealed class TraktMoviesMostPlayedRequest : ATraktMoviesMostPWCRequest<TraktMostPWCMovie>
    {
        public override string UriTemplate => "movies/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
