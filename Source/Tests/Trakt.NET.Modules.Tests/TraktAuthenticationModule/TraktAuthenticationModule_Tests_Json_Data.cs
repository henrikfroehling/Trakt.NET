namespace TraktNet.Modules.Tests.TraktAuthenticationModule
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TraktNet.Core;

    public partial class TraktAuthenticationModule_Tests
    {
        private const string CUSTOM_CLIENT_ID = "customClientId";
        private const string CUSTOM_REDIRECT_URI = "customRedirectUri";
        private const string CUSTOM_STATE = "customState";
        private const string MOCK_DEVICE_CODE = "mockDeviceCode";
        private const string MOCK_DEVICE_USER_CODE = "5055CC52";
        private const string DEVICE_VERIFICATION_URL = "https://trakt.tv/activate";
        private const string MOCK_AUTH_CODE = "mockAuthCode";
        private const uint DEVICE_EXPIRES_IN_SECONDS = 600;
        private const uint DEVICE_INTERVAL_IN_SECONDS = 6;

        private static async Task<string> BuildEncodedAuthorizeUrl(bool staging, string clientId, string redirectUri, string state = null)
        {
            const string oauthAuthorizeUri = Constants.OAuthAuthorizeUri;
            string baseUrl = staging ? Constants.OAuthBaseAuthorizeStagingUrl : Constants.OAuthBaseAuthorizeUrl;

            IDictionary<string, string> uriParams = new Dictionary<string, string>
            {
                ["response_type"] = "code",
                ["client_id"] = clientId,
                ["redirect_uri"] = redirectUri
            };

            if (!string.IsNullOrEmpty(state))
                uriParams["state"] = state;

            var encodedUriContent = new FormUrlEncodedContent(uriParams);
            string encodedUri = await encodedUriContent.ReadAsStringAsync();

            return $"{baseUrl}/{oauthAuthorizeUri}?{encodedUri}";
        }

        private const string SYNC_LAST_ACTIVITIES_JSON =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";
    }
}
