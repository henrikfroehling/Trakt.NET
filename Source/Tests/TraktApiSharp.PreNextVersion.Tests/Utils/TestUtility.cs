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
    using TraktApiSharp.Requests.Handler;

    public static class TestUtility
    {
        private const string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
        private const string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
        private const string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
        private const string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";
        private const string HEADER_TRENDING_USER_COUNT_KEY = "X-Trending-User-Count";
        private const string HEADER_SORT_BY_KEY = "X-Sort-By";
        private const string HEADER_SORT_HOW_KEY = "X-Sort-How";
        private const string HEADER_STARTDATE_KEY = "X-Start-Date";
        private const string HEADER_ENDDATE_KEY = "X-End-Date";
        private const string HEADER_PRIVATE_USER_KEY = "X-Private-User";

        private static MockHttpMessageHandler MOCK_HTTP;
        private static string BASE_URL;

        private static TraktAuthorization MOCK_AUTHORIZATION = new TraktAuthorization { AccessToken = "mock_access_token", ExpiresInSeconds = 3600 };

        private static readonly string TRAKT_CLIENT_ID = "traktClientId";
        private static readonly string TRAKT_CLIENT_SECRET = "traktClientSecret";
        private static readonly string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        public static TraktClient MOCK_TEST_CLIENT = new TraktClient(TRAKT_CLIENT_ID, TRAKT_CLIENT_SECRET);

        public static void SetupMockHttpClient()
        {
            BASE_URL = MOCK_TEST_CLIENT.Configuration.BaseUrl;
            MOCK_HTTP = new MockHttpMessageHandler();

            TraktConfiguration.HTTP_CLIENT = new HttpClient(MOCK_HTTP);

            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Add("trakt-api-key", $"{TRAKT_CLIENT_ID}");
            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Add("trakt-api-version", "2");

            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // ------------------------------------------------------

            RequestHandler.s_httpClient = new HttpClient(MOCK_HTTP);

            RequestHandler.s_httpClient.DefaultRequestHeaders.Add("trakt-api-key", $"{TRAKT_CLIENT_ID}");
            RequestHandler.s_httpClient.DefaultRequestHeaders.Add("trakt-api-version", "2");

            RequestHandler.s_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void SetupMockAuthenticationHttpClient()
        {
            BASE_URL = MOCK_TEST_CLIENT.Configuration.BaseUrl;
            MOCK_HTTP = new MockHttpMessageHandler();
            TraktConfiguration.HTTP_CLIENT = new HttpClient(MOCK_HTTP);
            TraktConfiguration.HTTP_CLIENT.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // ------------------------------------------------------

            RequestHandler.s_httpClient = new HttpClient(MOCK_HTTP);
            RequestHandler.s_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static void ResetMockHttpClient()
        {
            MOCK_TEST_CLIENT.Configuration.ForceAuthorization = false;
            TraktConfiguration.HTTP_CLIENT = null;

            // ------------------------------------------------------

            RequestHandler.s_httpClient = null;
        }

        public static void ClearMockHttpClient()
        {
            MOCK_TEST_CLIENT.Configuration.ForceAuthorization = false;
            MOCK_HTTP.Clear();
        }

        public static void SetDefaultClientValues()
        {
            MOCK_TEST_CLIENT.Should().NotBeNull();

            MOCK_TEST_CLIENT.ClientId = TRAKT_CLIENT_ID;
            MOCK_TEST_CLIENT.ClientSecret = TRAKT_CLIENT_SECRET;
            MOCK_TEST_CLIENT.Authentication.RedirectUri = DEFAULT_REDIRECT_URI;
        }

        public static void SetupMockAuthenticationResponse(string url, string requestContent, string responseContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{url}")
                     .WithContent(requestContent)
                     .Respond("application/json", responseContent);
        }

        public static void AddMockExpectationResponse(string url, string requestContent, string responseContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.Expect($"{BASE_URL}{url}")
                     .WithContent(requestContent)
                     .Respond("application/json", responseContent);
        }

        public static void VerifyNoOutstandingExceptations()
        {
            MOCK_HTTP.Should().NotBeNull();
            MOCK_HTTP.VerifyNoOutstandingExpectation();
        }

        public static void SetupMockAuthenticationTokenRevokeResponse(string url, string requestContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{url}")
                     .WithFormData(requestContent)
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {MOCK_TEST_CLIENT.Authorization.AccessToken}" }
                     })
                     .Respond(HttpStatusCode.OK);
        }

        public static void SetupMockAuthenticationResponse(string url, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{url}")
                     .WithContent(requestContent)
                     .Respond(httpStatusCode, "application/json", responseContent);
        }

        public static void SetupMockAuthenticationErrorResponse(string url, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Clear();

            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{url}")
                     .WithContent(requestContent)
                     .Respond(httpStatusCode, "application/json", responseContent);
        }

        public static void SetupMockAuthenticationErrorResponse(string url, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Clear();

            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{url}").Respond(httpStatusCode);
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
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond("application/json", responseContent);
        }

        public static void SetupMockResponseWithoutOAuthWithHeaders(string uri, string responseContent,
                                                                    string startDate = null, string endDate = null)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            var response = new HttpResponseMessage();

            if (!string.IsNullOrEmpty(startDate))
                response.Headers.Add(HEADER_STARTDATE_KEY, startDate);

            if (!string.IsNullOrEmpty(endDate))
                response.Headers.Add(HEADER_ENDDATE_KEY, endDate);

            response.Headers.Add("Accept", "application/json");
            response.Content = new StringContent(responseContent);

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond(response);
        }

        public static void SetupMockResponseWithoutOAuth(string uri, HttpStatusCode httpStatusCode)
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

        public static void SetupMockPaginationResponseWithoutOAuth(string uri, string responseContent,
                                                                   uint? page = null, uint? limit = null,
                                                                   int? pageCount = null, int? itemCount = null,
                                                                   int? userCount = null, string sortBy = null,
                                                                   string sortHow = null)
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

            if (!string.IsNullOrEmpty(sortBy))
                response.Headers.Add(HEADER_SORT_BY_KEY, sortBy);

            if (!string.IsNullOrEmpty(sortHow))
                response.Headers.Add(HEADER_SORT_HOW_KEY, sortHow);

            response.Headers.Add("Accept", "application/json");
            response.Content = new StringContent(responseContent);

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" }
                     })
                     .Respond(response);
        }

        public static void SetupMockResponseWithOAuth(string uri, string responseContent)
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

        public static void SetupMockResponseWithOAuthWithHeaders(string uri, string responseContent,
                                                                 string startDate = null, string endDate = null)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();
            MOCK_AUTHORIZATION.Should().NotBeNull();
            MOCK_AUTHORIZATION.AccessToken.Should().NotBeNullOrEmpty();

            MOCK_TEST_CLIENT.Authorization = MOCK_AUTHORIZATION;

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            var response = new HttpResponseMessage();

            if (!string.IsNullOrEmpty(startDate))
                response.Headers.Add(HEADER_STARTDATE_KEY, startDate);

            if (!string.IsNullOrEmpty(endDate))
                response.Headers.Add(HEADER_ENDDATE_KEY, endDate);

            response.Headers.Add("Accept", "application/json");
            response.Content = new StringContent(responseContent);

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {MOCK_AUTHORIZATION.AccessToken}" }
                     })
                     .Respond(response);
        }

        public static void SetupMockResponseWithOAuth(string uri, string responseContent, TraktAuthorization authorization)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();

            MOCK_TEST_CLIENT.Authorization = authorization;

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {authorization.AccessToken}" }
                     })
                     .Respond("application/json", responseContent);
        }

        public static void SetupMockResponseWithOAuthWithToken(string uri, string responseContent, string accessToken)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {accessToken}" }
                     })
                     .Respond("application/json", responseContent);
        }

        public static void SetupMockResponseWithOAuth(string uri, string requestContent, string responseContent)
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
                     .WithContent(requestContent)
                     .Respond("application/json", responseContent);
        }

        public static void SetupMockResponseWithOAuth(string uri, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();
            MOCK_AUTHORIZATION.Should().NotBeNull();
            MOCK_AUTHORIZATION.AccessToken.Should().NotBeNullOrEmpty();

            MOCK_TEST_CLIENT.Authorization = MOCK_AUTHORIZATION;

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {MOCK_AUTHORIZATION.AccessToken}" }
                     })
                     .Respond(httpStatusCode);
        }

        public static void SetupMockResponseWithOAuth(string uri, HttpStatusCode httpStatusCode, TraktAuthorization authorization)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();

            MOCK_TEST_CLIENT.Authorization = authorization;

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {authorization.AccessToken}" }
                     })
                     .Respond(httpStatusCode);
        }

        public static void AddMockExpectationResponse(string uri, HttpStatusCode httpStatusCode, TraktAuthorization authorization)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();

            MOCK_TEST_CLIENT.Authorization = authorization;

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.Expect($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {authorization.AccessToken}" }
                     })
                     .Respond(httpStatusCode);
        }

        public static void SetupMockResponseWithOAuthWithToken(string uri, HttpStatusCode httpStatusCode, string accessToken)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {accessToken}" }
                     })
                     .Respond(httpStatusCode);
        }

        public static void SetupMockPaginationResponseWithOAuth(string uri, string responseContent,
                                                                uint? page = null, uint? limit = null,
                                                                int? pageCount = null, int? itemCount = null,
                                                                int? userCount = null, string sortBy = null,
                                                                string sortHow = null)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();
            MOCK_AUTHORIZATION.Should().NotBeNull();
            MOCK_AUTHORIZATION.AccessToken.Should().NotBeNullOrEmpty();

            MOCK_TEST_CLIENT.Authorization = MOCK_AUTHORIZATION;

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

            if (!string.IsNullOrEmpty(sortBy))
                response.Headers.Add(HEADER_SORT_BY_KEY, sortBy);

            if (!string.IsNullOrEmpty(sortHow))
                response.Headers.Add(HEADER_SORT_HOW_KEY, sortHow);

            response.Headers.Add("Accept", "application/json");
            response.Content = new StringContent(responseContent);

            MOCK_HTTP.When($"{BASE_URL}{uri}")
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", $"{MOCK_TEST_CLIENT.ClientId}" },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {MOCK_AUTHORIZATION.AccessToken}" }
                     })
                     .Respond(response);
        }

        public static string SerializeObject(object value)
            => JsonConvert.SerializeObject(value, new JsonSerializerSettings()
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore
            });

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
