namespace TraktNet.Requests.Shows
{
    using Objects.Get.Shows;

    internal sealed class ShowsMostAnticipatedRequest : AShowsRequest<ITraktMostAnticipatedShow>
    {
        public override string UriTemplate => "shows/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        public override void Validate() { }
    }
}
