namespace TraktApiSharp.Core
{
    internal static class TraktConstants
    {
        internal const string API_URL = "https://api.trakt.tv/";
        internal const string API_STAGING_URL = "https://api-staging.trakt.tv/";

        internal const string APIClientIdHeaderKey = "trakt-api-key";
        internal const string APIVersionHeaderKey = "trakt-api-version";

        internal const string OAuthBaseAuthorizeUrl = "https://trakt.tv";

        internal const string OAuthAuthorizeUri = "oauth/authorize";
        internal const string OAuthTokenUri = "oauth/token";
        internal const string OAuthRevokeUri = "oauth/revoke";

        internal const string OAuthDeviceCodeUri = "oauth/device/code";
        internal const string OAuthDeviceTokenUri = "oauth/device/token";
    }
}
