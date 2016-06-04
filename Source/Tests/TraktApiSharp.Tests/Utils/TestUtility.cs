namespace TraktApiSharp.Tests.Utils
{
    using Core;
    using FluentAssertions;
    using Newtonsoft.Json;
    using RichardSzalay.MockHttp;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Reflection;
    using System.Text;
    using TraktApiSharp.Authentication;

    public static class TestUtility
    {
        private static string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
        private static string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
        private static string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
        private static string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";
        private static string HEADER_TRENDING_USER_COUNT_KEY = "X-Trending-User-Count";

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

        public static void SetupMockResponseWithoutOAuth(string uri, string responseContent)
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

        public static void SetupMockResponseWithoutOAuth(string uri, string requestContent, string responseContent)
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
                     .WithContent(requestContent)
                     .Respond("application/json", responseContent);
        }

        public static void SetupMockResponseWithoutOAuth(string uri, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", "trakt client id" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond(httpStatusCode);
        }

        public static void SetupMockPaginationResponseWithoutOAuth(string uri, string responseContent,
                                                                   int? page = null, int? limit = null,
                                                                   int? pageCount = null, int? itemCount = null,
                                                                   int? userCount = null)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            var response = new HttpResponseMessage();

            if (page.HasValue)
                response.Headers.Add(HEADER_PAGINATION_PAGE_KEY, $"{page.GetValueOrDefault()}");

            if (limit.HasValue)
                response.Headers.Add(HEADER_PAGINATION_LIMIT_KEY, $"{limit.GetValueOrDefault()}");

            if (pageCount.HasValue)
                response.Headers.Add(HEADER_PAGINATION_PAGE_COUNT_KEY, $"{pageCount.GetValueOrDefault()}");

            if (itemCount.HasValue)
                response.Headers.Add(HEADER_PAGINATION_ITEM_COUNT_KEY, $"{itemCount.GetValueOrDefault()}");

            if (userCount.HasValue)
                response.Headers.Add(HEADER_TRENDING_USER_COUNT_KEY, $"{userCount.Value}");

            response.Headers.Add("Accept", "application/json");
            response.Content = new StringContent(responseContent);

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", "trakt client id" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond(response);
        }

        public static void SetupMockResponseWithOAuth(string uri, string responseContent)
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

        public static void SetupMockResponseWithOAuth(string uri, string requestContent, string responseContent)
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
                     .WithContent(requestContent)
                     .Respond("application/json", responseContent);
        }

        public static void SetupMockResponseWithOAuth(string uri, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();
            MOCK_ACCESS_TOKEN.Should().NotBeNull();
            MOCK_ACCESS_TOKEN.AccessToken.Should().NotBeNullOrEmpty();

            MOCK_TEST_CLIENT.Authentication.AccessToken = MOCK_ACCESS_TOKEN;

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", "trakt client id" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {MOCK_ACCESS_TOKEN.AccessToken}" }
                     })
                     .Respond(httpStatusCode);
        }

        public static void SetupMockPaginationResponseWithOAuth(string uri, string responseContent,
                                                                int? page = null, int? limit = null,
                                                                int? pageCount = null, int? itemCount = null,
                                                                int? userCount = null)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();
            MOCK_ACCESS_TOKEN.Should().NotBeNull();
            MOCK_ACCESS_TOKEN.AccessToken.Should().NotBeNullOrEmpty();

            MOCK_TEST_CLIENT.Authentication.AccessToken = MOCK_ACCESS_TOKEN;

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            var response = new HttpResponseMessage();

            if (page.HasValue)
                response.Headers.Add(HEADER_PAGINATION_PAGE_KEY, $"{page.GetValueOrDefault()}");

            if (limit.HasValue)
                response.Headers.Add(HEADER_PAGINATION_LIMIT_KEY, $"{limit.GetValueOrDefault()}");

            if (pageCount.HasValue)
                response.Headers.Add(HEADER_PAGINATION_PAGE_COUNT_KEY, $"{pageCount.GetValueOrDefault()}");

            if (itemCount.HasValue)
                response.Headers.Add(HEADER_PAGINATION_ITEM_COUNT_KEY, $"{itemCount.GetValueOrDefault()}");

            if (userCount.HasValue)
                response.Headers.Add(HEADER_TRENDING_USER_COUNT_KEY, $"{userCount.Value}");

            response.Headers.Add("Accept", "application/json");
            response.Content = new StringContent(responseContent);

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", "trakt client id" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {MOCK_ACCESS_TOKEN.AccessToken}" }
                     })
                     .Respond(response);
        }

        public static string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value, new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore
            });
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
