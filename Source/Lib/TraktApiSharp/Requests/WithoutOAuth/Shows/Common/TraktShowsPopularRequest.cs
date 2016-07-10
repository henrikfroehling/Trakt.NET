namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Shows;

    internal class TraktShowsPopularRequest : TraktGetRequest<TraktPaginationListResult<TraktShow>, TraktShow>
    {
        internal TraktShowsPopularRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "shows/popular{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}
