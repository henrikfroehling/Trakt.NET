namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies;

    internal sealed class TraktMoviesPopularRequest : ATraktMoviesRequest<TraktMovie>
    {
        internal TraktMoviesPopularRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "movies/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";
    }
}
