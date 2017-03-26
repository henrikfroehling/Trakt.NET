namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    internal sealed class TraktShowsPopularRequest : ATraktShowsRequest<TraktShow>
    {
        public override string UriTemplate => "shows/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
