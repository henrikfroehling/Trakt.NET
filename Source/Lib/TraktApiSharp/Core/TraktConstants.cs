namespace TraktApiSharp.Core
{
    using Newtonsoft.Json;

    internal static class TraktConstants
    {
        internal const string APIClientIdHeaderKey = "trakt-api-key";
        internal const string APIVersionHeaderKey = "trakt-api-version";

        internal const string OAuthBaseAuthorizeUrl = "https://trakt.tv";

        internal const string OAuthAuthorizeUri = "oauth/authorize";
        internal const string OAuthTokenUri = "oauth/token";
        internal const string OAuthRevokeUri = "oauth/revoke";

        internal const string OAuthDeviceCodeUri = "oauth/device/code";
        internal const string OAuthDeviceTokenUri = "oauth/device/token";

        internal static readonly JsonSerializerSettings DEFAULT_JSON_SETTINGS
            = new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore
            };
    }
}
