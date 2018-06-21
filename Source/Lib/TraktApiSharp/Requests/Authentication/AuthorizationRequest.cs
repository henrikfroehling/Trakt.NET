namespace TraktNet.Requests.Authentication
{
    using Objects.Authentication;

    internal sealed class AuthorizationRequest : AAuthorizationRequest<ITraktAuthorization, AuthorizationRequestBody>
    {
        public override string UriTemplate => "oauth/token";
    }
}
