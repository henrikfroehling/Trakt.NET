namespace TraktApiSharp.Tests.Utils
{
    using Core;
    using FluentAssertions;
    using RichardSzalay.MockHttp;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Text;
    using TraktApiSharp.Authentication;

    public static class TestUtility
    {
        private static MockHttpMessageHandler MOCK_HTTP;
        private static string BASE_URL;

        private static TraktAccessToken MOCK_ACCESS_TOKEN = new TraktAccessToken { AccessToken = "mock_access_token", ExpiresInSeconds = 3600 };

        public static TraktClient MOCK_TEST_CLIENT = new TraktClient("trakt client id");

        public static void SetupMockHttpClient()
        {
            BASE_URL = MOCK_TEST_CLIENT.Configuration.BaseUrl;
            MOCK_HTTP = new MockHttpMessageHandler();

            TraktConfiguration.HTTP_CLIENT = new HttpClient(MOCK_HTTP);

            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Add("trakt-api-key", "trakt client id");
            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Add("trakt-api-version", "2");

            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void ResetMockHttpClient()
        {
            TraktConfiguration.HTTP_CLIENT = null;
        }

        public static void ClearMockHttpClient()
        {
            MOCK_HTTP.Clear();
        }

        public static void SetupMockRequestWithoutOAuth(string uri, string responseContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", "trakt client id" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond("application/json", responseContent);
        }

        public static void SetupMockRequestWithOAuth(string uri, string responseContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();
            MOCK_ACCESS_TOKEN.Should().NotBeNull();
            MOCK_ACCESS_TOKEN.AccessToken.Should().NotBeNullOrEmpty();

            MOCK_TEST_CLIENT.Authentication.AccessToken = MOCK_ACCESS_TOKEN;

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", "trakt client id" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {MOCK_ACCESS_TOKEN.AccessToken}" }
                     })
                     .Respond("application/json", responseContent);
        }

        public static string GetDataFilePath(string filePath)
        {
            var execAssemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
            return !string.IsNullOrEmpty(filePath) ? Path.Combine(execAssemblyLocation, "TestData", filePath) : string.Empty;
        }

        public static string ReadFileContents(string filePath)
        {
            var jsonFile = File.ReadAllText(GetDataFilePath(filePath), Encoding.UTF8);
            return !string.IsNullOrEmpty(jsonFile) ? jsonFile : string.Empty;
        }
    }
}
