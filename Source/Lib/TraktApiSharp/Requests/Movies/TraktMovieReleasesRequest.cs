namespace TraktApiSharp.Requests.Movies
{
    using Base.Get;
    using Objects;
    using Objects.Movies;

    internal class TraktMovieReleasesRequest : TraktGetByIdRequest<TraktListResult<TraktMovieRelease>, TraktMovieRelease>
    {
        internal TraktMovieReleasesRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/releases";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;
    }
}
