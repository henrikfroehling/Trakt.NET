namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;

    internal sealed class TraktShowsMostWatchedRequest : ATraktShowsMostPWCRequest<TraktMostWatchedShow>
    {
        internal TraktShowsMostWatchedRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "shows/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";
    }
}
