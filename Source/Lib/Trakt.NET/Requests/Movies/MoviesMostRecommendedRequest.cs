namespace TraktNet.Requests.Movies
{
    using Base;
    using Objects.Get.Movies;

    internal sealed class MoviesMostRecommendedRequest : AMostRecommendedRequest<ITraktMostRecommendedMovie>
    {
        public override string UriTemplate => "movies/recommended{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        public override void Validate() { }
    }
}
