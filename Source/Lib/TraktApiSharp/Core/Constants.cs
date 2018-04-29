namespace TraktApiSharp.Core
{
    internal static class Constants
    {
        internal const string API_URL = "https://api.trakt.tv/";
        internal const string API_STAGING_URL = "https://api-staging.trakt.tv/";

        internal const string APIClientIdHeaderKey = "trakt-api-key";
        internal const string APIVersionHeaderKey = "trakt-api-version";

        internal const string OAuthBaseAuthorizeUrl = "https://trakt.tv";
        internal const string OAuthBaseAuthorizeStagingUrl = "https://staging.trakt.tv";

        internal const string OAuthAuthorizeUri = "oauth/authorize";
        internal const string OAuthTokenUri = "oauth/token";
        internal const string OAuthRevokeUri = "oauth/revoke";

        internal const string OAuthDeviceCodeUri = "oauth/device/code";
        internal const string OAuthDeviceTokenUri = "oauth/device/token";

        internal const string MEDIA_TYPE = "application/json";
        internal const string MEDIA_TYPE_URL_ENCODED = "application/x-www-form-urlencoded";
    }
}
