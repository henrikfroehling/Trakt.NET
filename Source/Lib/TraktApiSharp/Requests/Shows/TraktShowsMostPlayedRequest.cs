namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows;

    internal sealed class TraktShowsMostPlayedRequest : ATraktShowsMostPWCRequest<TraktMostPWCShow>
    {
        public override string UriTemplate => "shows/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
