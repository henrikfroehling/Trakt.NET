namespace TraktApiSharp.Tests.TestUtils
{
    using FluentAssertions;
    using RichardSzalay.MockHttp;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using TraktApiSharp.Core;
    using TraktApiSharp.Objects.Authentication.Implementations;
    using TraktApiSharp.Objects.Json;
    using TraktApiSharp.Requests.Handler;

    internal static class TestUtility
    {
        private static MockHttpMessageHandler MOCK_HTTP;
        private static string BASE_URL;

        private const string TRAKT_CLIENT_ID = "traktClientId";
        private const string TRAKT_CLIENT_SECRET = "traktClientSecret";
        private const string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        internal static TraktClient MOCK_TEST_CLIENT = new TraktClient(TRAKT_CLIENT_ID, TRAKT_CLIENT_SECRET);

        internal static TraktClient GetMockClient(string uri, string responseContent)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupMockResponse(uri, responseContent);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static TraktClient GetMockClient(string uri, string responseContent,
                                                  uint? page = null, uint? limit = null,
                                                  int? pageCount = null, int? itemCount = null,
                                                  int? userCount = null, string startDate = null,
                                                  string endDate = null, string sortBy = null,
                                                  string sortHow = null)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupMockResponse(uri, responseContent, page, limit, pageCount, itemCount, userCount, startDate, endDate, sortBy, sortHow);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static TraktClient GetMockClient(string uri, HttpStatusCode httpStatusCode)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupMockResponse(uri, httpStatusCode);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static TraktClient GetOAuthMockClient(string uri, string responseContent,
                                                       uint? page = null, uint? limit = null,
                                                       int? pageCount = null, int? itemCount = null,
                                                       int? userCount = null, string startDate = null,
                                                       string endDate = null, string sortBy = null,
                                                       string sortHow = null)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupOAuthMockResponse(uri, responseContent, page, limit, pageCount, itemCount, userCount, startDate, endDate, sortBy, sortHow);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider)
            {
                Authorization = TestConstants.MOCK_AUTHORIZATION
            };
        }

        internal static TraktClient GetOAuthMockClient(string uri, string requestContent, string responseContent)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupOAuthMockResponse(uri, requestContent, responseContent);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider)
            {
                Authorization = TestConstants.MOCK_AUTHORIZATION
            };
        }

        internal static TraktClient GetOAuthMockClient(string uri, HttpStatusCode httpStatusCode)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupOAuthMockResponse(uri, httpStatusCode);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider)
            {
                Authorization = TestConstants.MOCK_AUTHORIZATION
            };
        }

        internal static ulong CalculateTimestamp(DateTime createdAt)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long originSeconds = origin.Ticks / TimeSpan.TicksPerSecond;
            DateTime utcCreatedAt = createdAt.ToUniversalTime();
            long utcCreatedAtSeconds = utcCreatedAt.Ticks / TimeSpan.TicksPerSecond;
            return (ulong)(utcCreatedAtSeconds - originSeconds);
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

        internal static void ClearMockHttpClient()
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

        public static void SetupMockResponseWithOAuth(string uri, string responseContent, TraktAuthorization authorization)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();

            MOCK_TEST_CLIENT.Authorization = authorization;

            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When(BASE_URL + uri)
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", MOCK_TEST_CLIENT.ClientId },
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

            MOCK_HTTP.When(BASE_URL + uri)
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", MOCK_TEST_CLIENT.ClientId },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {accessToken}" }
                     })
                     .Respond("application/json", responseContent);
        }

        public static void SetupMockResponseWithOAuth(string uri, HttpStatusCode httpStatusCode, TraktAuthorization authorization)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();

            MOCK_TEST_CLIENT.Authorization = authorization;

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When(BASE_URL + uri)
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", MOCK_TEST_CLIENT.ClientId },
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

            MOCK_HTTP.When(BASE_URL + uri)
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", MOCK_TEST_CLIENT.ClientId },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {accessToken}" }
                     })
                     .Respond(httpStatusCode);
        }

        public static void AddMockExpectationResponse(string url, string requestContent, string responseContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.Expect(BASE_URL + url)
                     .WithContent(requestContent)
                     .Respond("application/json", responseContent);
        }

        public static void AddMockExpectationResponse(string uri, HttpStatusCode httpStatusCode, TraktAuthorization authorization)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();
            MOCK_TEST_CLIENT.Should().NotBeNull();

            MOCK_TEST_CLIENT.Authorization = authorization;

            uri.Should().NotBeNullOrEmpty();

            MOCK_HTTP.Expect(BASE_URL + uri)
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", MOCK_TEST_CLIENT.ClientId },
                         { "trakt-api-version", "2" },
                         { "Authorization", $"Bearer {authorization.AccessToken}" }
                     })
                     .Respond(httpStatusCode);
        }

        public static void VerifyNoOutstandingExceptations()
        {
            MOCK_HTTP.Should().NotBeNull();
            MOCK_HTTP.VerifyNoOutstandingExpectation();
        }

        public static void SetupMockAuthenticationErrorResponse(string url, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Clear();

            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When(BASE_URL + url)
                     .WithContent(requestContent)
                     .Respond(httpStatusCode, "application/json", responseContent);
        }

        public static void SetupMockAuthenticationErrorResponse(string url, HttpStatusCode httpStatusCode)
        {
            MOCK_HTTP.Clear();

            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When(BASE_URL + url).Respond(httpStatusCode);
        }

        public static void SetupMockAuthenticationTokenRevokeResponse(string url, string requestContent)
        {
            MOCK_HTTP.Should().NotBeNull();
            BASE_URL.Should().NotBeNullOrEmpty();

            url.Should().NotBeNullOrEmpty();
            requestContent.Should().NotBeNullOrEmpty();

            MOCK_HTTP.When(BASE_URL + url)
                     .WithFormData(requestContent)
                     .WithHeaders(new Dictionary<string, string>
                     {
                         { "trakt-api-key", MOCK_TEST_CLIENT.ClientId },
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

            MOCK_HTTP.When(BASE_URL + url)
                     .WithContent(requestContent)
                     .Respond(httpStatusCode, "application/json", responseContent);
        }

        public static Task<string> SerializeObject<TObjectType>(TObjectType obj)
        {
            IObjectJsonWriter<TObjectType> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<TObjectType>();
            return objectJsonWriter.WriteObjectAsync(obj);
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
