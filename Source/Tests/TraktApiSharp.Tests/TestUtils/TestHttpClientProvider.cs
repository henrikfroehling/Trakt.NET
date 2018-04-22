namespace TraktApiSharp.Tests.TestUtils
{
    using FluentAssertions;
    using RichardSzalay.MockHttp;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using TraktApiSharp.Requests.Handler;

    internal class TestHttpClientProvider : IHttpClientProvider
    {
        private const string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
        private const string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
        private const string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
        private const string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";
        private const string TRAKT_API_HEADER_KEY = "trakt-api-key";
        private const string TRAKT_API_VERSION_HEADER_KEY = "trakt-api-version";
        private const string ACCEPT_MEDIA_TYPE = "application/json";

        private readonly string _baseUrl;
        private readonly string _clientId;
        private readonly string _clientSecret;
        private readonly MockHttpMessageHandler _mockHttpMessageHandler;

        public TestHttpClientProvider(string baseUrl)
        {
            _baseUrl = baseUrl;
            _clientId = TestConstants.TRAKT_CLIENT_ID;
            _clientSecret = TestConstants.TRAKT_CLIENT_SECRET;
            _mockHttpMessageHandler = new MockHttpMessageHandler();
        }

        public HttpClient GetHttpClient()
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            var httpClient = new HttpClient(_mockHttpMessageHandler);
            httpClient.DefaultRequestHeaders.Add(TRAKT_API_HEADER_KEY, _clientId);
            httpClient.DefaultRequestHeaders.Add(TRAKT_API_VERSION_HEADER_KEY, "2");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ACCEPT_MEDIA_TYPE));
            return httpClient;
        }

        public HttpClient GetAuthorizationHttpClient()
        {
            throw new System.NotImplementedException();
        }

        internal void SetupMockResponse(string uri, string responseContent)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            _clientId.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();
            responseContent.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" }
                })
                .Respond(ACCEPT_MEDIA_TYPE, responseContent);
        }

        internal void SetupMockResponse(string uri, string responseContent,
                                        uint? page = null, uint? limit = null,
                                        int? pageCount = null, int? itemCount = null)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            _clientId.Should().NotBeNullOrEmpty();
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

            response.Headers.Add("Accept", ACCEPT_MEDIA_TYPE);
            response.Content = new StringContent(responseContent);

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" }
                })
                .Respond(r => response);
        }

        internal void SetupMockResponse(string uri, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TRAKT_API_HEADER_KEY, _clientId },
                    { TRAKT_API_VERSION_HEADER_KEY, "2" }
                })
                .Respond(httpStatusCode);
        }
    }
}
