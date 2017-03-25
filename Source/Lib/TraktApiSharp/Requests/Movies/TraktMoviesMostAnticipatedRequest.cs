namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    internal sealed class TraktMoviesMostAnticipatedRequest : ATraktMoviesRequest<TraktMostAnticipatedMovie>
    {
        public override string UriTemplate => "movies/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
