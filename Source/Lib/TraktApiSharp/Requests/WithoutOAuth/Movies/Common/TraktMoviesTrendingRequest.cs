namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies.Common;

    internal class TraktMoviesTrendingRequest : TraktGetRequest<TraktPaginationListResult<TraktMoviesTrendingItem>, TraktMoviesTrendingItem>
    {
        internal TraktMoviesTrendingRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "movies/trending";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
