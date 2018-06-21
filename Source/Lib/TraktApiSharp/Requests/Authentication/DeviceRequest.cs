namespace TraktNet.Requests.Authentication
{
    using Objects.Authentication;

    internal sealed class DeviceRequest : AAuthorizationRequest<ITraktDevice, DeviceRequestBody>
    {
        public override string UriTemplate => "oauth/device/code";
    }
}
