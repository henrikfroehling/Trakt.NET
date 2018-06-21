namespace TraktNet.Requests.Authentication
{
    using Objects.Authentication;

    internal sealed class AuthorizationPollRequest : AAuthorizationRequest<ITraktAuthorization, AuthorizationPollRequestBody>
    {
        public override string UriTemplate => "oauth/device/token";
    }
}
