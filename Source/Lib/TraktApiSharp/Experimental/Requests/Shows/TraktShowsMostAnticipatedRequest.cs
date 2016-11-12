namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;

    internal sealed class TraktShowsMostAnticipatedRequest : ATraktShowsRequest<TraktMostAnticipatedShow>
    {
        public TraktShowsMostAnticipatedRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "shows/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";
    }
}
