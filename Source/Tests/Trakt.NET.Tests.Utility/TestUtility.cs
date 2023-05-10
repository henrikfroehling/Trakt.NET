namespace Trakt.NET.Tests.Utility
{
    using System;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using TraktNet;
    using TraktNet.Core;
    using TraktNet.Enums;
    using TraktNet.Objects.Json;
    using TraktNet.Requests.Handler;

    internal static class TestUtility
    {
        internal static TraktClient GetMockClient(string uri, string responseContent)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupMockResponse(uri, responseContent);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static void ResetMockClient(this TraktClient client, string uri, string responseContent,
                                             uint? page = null, uint? limit = null,
                                             int? pageCount = null, int? itemCount = null,
                                             int? userCount = null, string startDate = null,
                                             string endDate = null, TraktSortBy sortBy = null,
                                             TraktSortHow sortHow = null)
        {
            (client.HttpClientProvider as TestHttpClientProvider).Clear();

            (client.HttpClientProvider as TestHttpClientProvider)
                .SetupMockResponse(uri, responseContent, page, limit, pageCount, itemCount, userCount, startDate, endDate, sortBy, sortHow);
        }

        internal static void ResetOAuthMockClient(this TraktClient client, string uri, string responseContent,
                                                  uint? page = null, uint? limit = null,
                                                  int? pageCount = null, int? itemCount = null,
                                                  int? userCount = null, string startDate = null,
                                                  string endDate = null, TraktSortBy sortBy = null,
                                                  TraktSortHow sortHow = null)
        {
            (client.HttpClientProvider as TestHttpClientProvider).Clear();

            (client.HttpClientProvider as TestHttpClientProvider)
                .SetupOAuthMockResponse(uri, responseContent, page, limit, pageCount, itemCount, userCount, startDate, endDate, sortBy, sortHow);
        }

        internal static TraktClient GetMockClient(string uri, string responseContent,
                                                  uint? page = null, uint? limit = null,
                                                  int? pageCount = null, int? itemCount = null,
                                                  int? userCount = null, string startDate = null,
                                                  string endDate = null, TraktSortBy sortBy = null,
                                                  TraktSortHow sortHow = null)
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
                                                       string endDate = null, TraktSortBy sortBy = null,
                                                       TraktSortHow sortHow = null)
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

        internal static TraktClient GetAuthenticationMockClient()
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static TraktClient GetAuthenticationMockClient(string uri, string requestContent)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupAuthenticationMockResponse(uri, requestContent);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static TraktClient GetAuthenticationMockClient(string uri, string requestContent, string responseContent)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupAuthenticationMockResponse(uri, requestContent, responseContent);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static TraktClient GetAuthenticationMockClient(string uri, HttpStatusCode httpStatusCode)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupAuthenticationMockResponse(uri, httpStatusCode);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static TraktClient GetAuthenticationMockClient(string uri, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            var httpClientProvider = new TestHttpClientProvider(Constants.API_URL);
            httpClientProvider.SetupAuthenticationMockResponse(uri, requestContent, responseContent, httpStatusCode);
            return new TraktClient(TestConstants.TRAKT_CLIENT_ID, TestConstants.TRAKT_CLIENT_SECRET, httpClientProvider);
        }

        internal static void ChangeAuthenticationMockResponse(TestHttpClientProvider httpClientProvider, string uri, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            httpClientProvider.ChangeAuthenticationMockResponse(uri, requestContent, responseContent, httpStatusCode);
        }

        internal static void AddMockExpectationResponse(TestHttpClientProvider httpClientProvider, string uri, string requestContent, string responseContent)
        {
            httpClientProvider.AddExpectationMockResponse(uri, requestContent, responseContent);
        }

        internal static void AddMockExpectationResponse(TestHttpClientProvider httpClientProvider, string uri, string requestContent, string responseContent, HttpStatusCode httpStatusCode)
        {
            httpClientProvider.AddExpectationMockResponse(uri, requestContent, responseContent, httpStatusCode);
        }

        internal static void AddMockExpectationResponse(TestHttpClientProvider httpClientProvider, string uri, HttpStatusCode httpStatusCode)
        {
            httpClientProvider.AddExpectationMockResponse(uri, httpStatusCode);
        }

        internal static void VerifyNoOutstandingExpectations(TestHttpClientProvider httpClientProvider)
        {
            httpClientProvider.VerifyNoOutstandingExpectations();
        }

        internal static ulong CalculateTimestamp(DateTime createdAt)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            long originSeconds = origin.Ticks / TimeSpan.TicksPerSecond;
            DateTime utcCreatedAt = createdAt.ToUniversalTime();
            long utcCreatedAtSeconds = utcCreatedAt.Ticks / TimeSpan.TicksPerSecond;
            return (ulong)(utcCreatedAtSeconds - originSeconds);
        }

        internal static Task<string> SerializeObject<TObjectType>(TObjectType obj)
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

        internal static string EncodeForURL(string uri) => RequestUri.Encode(uri);
    }
}
