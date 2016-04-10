namespace TraktApiSharp.Requests.Movies
{
    using Base.Get;
    using Objects;
    using Objects.Movies;

    internal class TraktMovieRelatedMoviesRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktMovie>, TraktMovie>
    {
        internal TraktMovieRelatedMoviesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/related";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
