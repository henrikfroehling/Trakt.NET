namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects;
    using Objects.Movies;

    internal class TraktMovieWatchingUsersRequest : TraktGetByIdRequest<TraktListResult<TraktMovieWatchingUser>, TraktMovieWatchingUser>
    {
        internal TraktMovieWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/watching";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}
