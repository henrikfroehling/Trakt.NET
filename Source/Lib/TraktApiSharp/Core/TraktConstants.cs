namespace TraktApiSharp.Core
{
    internal static class TraktConstants
    {
        internal static string OAuthBaseAuthorizeUrl => "https://trakt.tv";

        internal static string OAuthAuthorizeUri => "oauth/authorize";
        internal static string OAuthTokenUri => "oauth/token";
        internal static string OAuthRevokeUri => "oauth/revoke";

        internal static string OAuthDeviceCodeUri => "oauth/device/code";
        internal static string OAuthDeviceTokenUri => "oauth/device/token";
    }
}
