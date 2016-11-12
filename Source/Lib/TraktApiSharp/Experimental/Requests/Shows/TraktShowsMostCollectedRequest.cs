namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows.Common;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowsMostCollectedRequest : ATraktShowsMostPWCRequest<TraktMostCollectedShow>
    {
        public TraktShowsMostCollectedRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "shows/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";
    }
}
