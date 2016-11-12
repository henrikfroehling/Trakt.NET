namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;

    internal sealed class TraktShowsMostPlayedRequest : ATraktShowsMostPWCRequest<TraktMostPlayedShow>
    {
        public TraktShowsMostPlayedRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "shows/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";
    }
}
