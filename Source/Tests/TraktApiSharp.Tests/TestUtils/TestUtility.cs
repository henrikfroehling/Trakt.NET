namespace TraktApiSharp.Tests.TestUtils
{
    using FluentAssertions;
    using RichardSzalay.MockHttp;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Requests.Handler;

    internal static class TestUtility
    {
        private static MockHttpMessageHandler MOCK_HTTP;
        private static string BASE_URL;

        private const string TRAKT_CLIENT_ID = "traktClientId";
        private const string TRAKT_CLIENT_SECRET = "traktClientSecret";
        private const string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        private static readonly TraktAuthorization MOCK_AUTHORIZATION = new TraktAuthorization { AccessToken = "mock_access_token", ExpiresInSeconds = 3600 };

        internal static TraktClient MOCK_TEST_CLIENT = new TraktClient(TRAKT_CLIENT_ID, TRAKT_CLIENT_SECRET);

        internal static void SetupMockHttpClient()
        {
            BASE_URL = MOCK_TEST_CLIENT.Configuration.BaseUrl;
            MOCK_HTTP = new MockHttpMessageHandler();

            RequestHandler.s_httpClient = new HttpClient(MOCK_HTTP);
            RequestHandler.s_httpClient.DefaultRequestHeaders.Add("trakt-api-key", $"{TRAKT_CLIENT_ID}");
            RequestHandler.s_httpClient.DefaultRequestHeaders.Add("trakt-api-version", "2");
            RequestHandler.s_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        internal static void ResetMockHttpClient()
        {
            MOCK_TEST_CLIENT.Configuration.ForceAuthorization = false;
            RequestHandler.s_httpClient = null;
        }

        internal static void ClearMockHttpClient()
        {
            MOCK_TEST_CLIENT.Configuration.ForceAuthorization = false;
            MOCK_HTTP.Clear();
        }

        internal static void SetupMockResponseWithoutOAuth(string uri, string responseContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond("application/json", responseContent);
        }

        internal static void SetupMockResponseWithoutOAuth(string uri, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond(httpStatusCode);
        }

        internal static void SetupMockResponseWithOAuth(string uri, string responseContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();
            MOCK_AUTHORIZATION.Should().NotBeNull();
            MOCK_AUTHORIZATION.AccessToken.Should().NotBeNullOrEmpty();

            MOCK_TEST_CLIENT.Authorization = MOCK_AUTHORIZATION;

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {MOCK_AUTHORIZATION.AccessToken}" }
                     })
                     .Respond("application/json", responseContent);
        }

        internal static Stream ToStream(this string str)
        {
            var stream = new MemoryStream();
            var streamWriter = new StreamWriter(stream);

            streamWriter.Write(str);
            streamWriter.Flush();
            stream.Position = 0;

            return stream;
        }
    }
}
