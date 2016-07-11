namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows.Common;

    internal class TraktShowsMostAnticipatedRequest : TraktGetRequest<TraktPaginationListResult<TraktMostAnticipatedShow>, TraktMostAnticipatedShow>
    {
        internal TraktShowsMostAnticipatedRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
