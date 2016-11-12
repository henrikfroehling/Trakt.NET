namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;

    internal sealed class TraktShowsMostWatchedRequest : ATraktShowsMostPWCRequest<TraktMostWatchedShow>
    {
        public TraktShowsMostWatchedRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "shows/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";
    }
}
