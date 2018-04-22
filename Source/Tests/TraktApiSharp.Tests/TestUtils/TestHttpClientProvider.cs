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
            httpClient.DefaultRequestHeaders.Add("trakt-api-key", _clientId);
            httpClient.DefaultRequestHeaders.Add("trakt-api-version", "2");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
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
                    { "trakt-api-key", _clientId },
                    { "trakt-api-version", "2" }
                })
                .Respond("application/json", responseContent);
        }

        internal void SetupMockResponse(string uri, HttpStatusCode httpStatusCode)
        {
            _mockHttpMessageHandler.Should().NotBeNull();
            _baseUrl.Should().NotBeNullOrEmpty();
            uri.Should().NotBeNullOrEmpty();

            _mockHttpMessageHandler.When(_baseUrl + uri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { "trakt-api-key", _clientId },
                    { "trakt-api-version", "2" }
                })
                .Respond(httpStatusCode);
        }
    }
}
