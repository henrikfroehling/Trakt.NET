namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowsPopularRequest : ATraktShowsRequest<TraktShow>
    {
        public TraktShowsPopularRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";
    }
}
