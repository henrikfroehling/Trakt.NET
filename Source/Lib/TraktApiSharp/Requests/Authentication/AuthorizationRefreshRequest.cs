namespace TraktApiSharp.Requests.Authentication
{
    using Objects.Authentication;

    internal sealed class AuthorizationRefreshRequest : AAuthorizationRequest<ITraktAuthorization, AuthorizationRefreshRequestBody>
    {
        public override string UriTemplate => "oauth/token";
    }
}
