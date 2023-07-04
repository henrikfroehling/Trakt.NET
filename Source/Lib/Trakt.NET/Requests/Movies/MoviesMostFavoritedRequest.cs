namespace TraktNet.Requests.Movies
{
    using Base;
    using Objects.Get.Movies;

    internal sealed class MoviesMostFavoritedRequest : AMostFavoritedRequest<ITraktMostFavoritedMovie>
    {
        public override string UriTemplate => "movies/favorited{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
