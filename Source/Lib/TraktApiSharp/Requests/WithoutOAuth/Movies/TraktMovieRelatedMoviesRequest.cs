namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies;

    internal class TraktMovieRelatedMoviesRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktMovie>, TraktMovie>
    {
        internal TraktMovieRelatedMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/related{?extended,page,limit}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
