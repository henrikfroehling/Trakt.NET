namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class MoviesMostAnticipatedRequest : AMoviesRequest<ITraktMostAnticipatedMovie>
    {
        public override string UriTemplate => "movies/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
