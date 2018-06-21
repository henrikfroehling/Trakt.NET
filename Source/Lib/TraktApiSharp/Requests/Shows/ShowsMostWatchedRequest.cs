namespace TraktNet.Requests.Shows
{
    using Objects.Get.Shows;

    internal sealed class ShowsMostWatchedRequest : AShowsMostPWCRequest<ITraktMostPWCShow>
    {
        public override string UriTemplate => "shows/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
