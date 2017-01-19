namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;

    internal sealed class TraktShowsMostPlayedRequest : ATraktShowsMostPWCRequest<TraktMostPlayedShow>
    {
        internal TraktShowsMostPlayedRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "shows/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";
    }
}
