namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;

    internal sealed class TraktShowsTrendingRequest : ATraktShowsRequest<TraktTrendingShow>
    {
        internal TraktShowsTrendingRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "shows/trending{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";
    }
}
