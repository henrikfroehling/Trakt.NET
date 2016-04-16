namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects;
    using Objects.Shows;

    internal class TraktShowWatchingUsersRequest : TraktGetByIdRequest<TraktListResult<TraktShowWatchingUser>, TraktShowWatchingUser>
    {
        internal TraktShowWatchingUsersRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/watching";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}
