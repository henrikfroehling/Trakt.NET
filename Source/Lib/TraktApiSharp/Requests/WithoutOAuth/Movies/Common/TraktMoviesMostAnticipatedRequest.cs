namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies.Common;

    internal class TraktMoviesMostAnticipatedRequest : TraktGetRequest<TraktPaginationListResult<TraktMoviesMostAnticipatedItem>, TraktMoviesMostAnticipatedItem>
    {
        internal TraktMoviesMostAnticipatedRequest(TraktClient client) : base(client) { }

        protected override string UriTemplate => "movies/anticipated";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
