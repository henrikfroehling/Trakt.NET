namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class TraktMoviesPopularRequest : ATraktMoviesRequest<TraktMovie>
    {
        public override string UriTemplate => "movies/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
