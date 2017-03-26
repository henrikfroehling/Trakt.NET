namespace TraktApiSharp.Requests.Shows
{
    using Objects.Get.Shows.Implementations;

    internal sealed class TraktShowsMostCollectedRequest : ATraktShowsMostPWCRequest<TraktMostPWCShow>
    {
        public override string UriTemplate => "shows/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
