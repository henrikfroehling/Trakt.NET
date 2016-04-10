namespace TraktApiSharp.Core
{
    public static class TraktConstants
    {
        public static string OAuthBaseAuthorizeUrl => "https://trakt.tv";

        public static string OAuthAuthorizeUri => "oauth/authorize";
        public static string OAuthTokenUri => "oauth/token";
        public static string OAuthRevokeUri => "oauth/revoke";

        public static string OAuthDeviceCodeUri => "oauth/device/code";
        public static string OAuthDeviceTokenUri => "oauth/device/token";
    }
}
