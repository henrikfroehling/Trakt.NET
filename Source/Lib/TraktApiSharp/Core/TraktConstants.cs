namespace TraktApiSharp.Core
{
    internal static class TraktConstants
    {
        internal static readonly string APIClientIdHeaderKey = "trakt-api-key";
        internal static readonly string APIVersionHeaderKey = "trakt-api-version";

        internal static readonly string OAuthBaseAuthorizeUrl = "https://trakt.tv";

        internal static readonly string OAuthAuthorizeUri = "oauth/authorize";
        internal static readonly string OAuthTokenUri = "oauth/token";
        internal static readonly string OAuthRevokeUri = "oauth/revoke";

        internal static readonly string OAuthDeviceCodeUri = "oauth/device/code";
        internal static readonly string OAuthDeviceTokenUri = "oauth/device/token";
    }
}
