namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows.Common;

    internal sealed class TraktShowsMostWatchedRequest : ATraktShowsMostPWCRequest<TraktMostWatchedShow>
    {
        public override string UriTemplate => "shows/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
