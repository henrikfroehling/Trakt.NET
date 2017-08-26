namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class MoviesMostCollectedRequest : AMoviesMostPWCRequest<ITraktMostPWCMovie>
    {
        public override string UriTemplate => "movies/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
