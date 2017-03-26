namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows.Implementations;

    internal sealed class TraktShowsTrendingRequest : ATraktShowsRequest<TraktTrendingShow>
    {
        public override string UriTemplate => "shows/trending{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
