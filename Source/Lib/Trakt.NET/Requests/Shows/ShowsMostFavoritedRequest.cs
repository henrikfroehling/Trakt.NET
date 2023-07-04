namespace TraktNet.Requests.Shows
{
    using Base;
    using Objects.Get.Shows;

    internal sealed class ShowsMostFavoritedRequest : AMostFavoritedRequest<ITraktMostFavoritedShow>
    {
        public override string UriTemplate => "shows/favorited{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
