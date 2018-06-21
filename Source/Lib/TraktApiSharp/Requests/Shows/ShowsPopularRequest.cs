namespace TraktNet.Requests.Shows
{
    using Objects.Get.Shows;

    internal sealed class ShowsPopularRequest : AShowsRequest<ITraktShow>
    {
        public override string UriTemplate => "shows/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
