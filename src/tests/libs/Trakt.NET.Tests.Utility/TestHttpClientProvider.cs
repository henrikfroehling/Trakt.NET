using RichardSzalay.MockHttp;
using System.Net;

#if TRAKT_NET_4XX_FRAMEWORK_TARGET
using System.Net.Http;
#endif

using System.Net.Http.Headers;
using System.Text;

namespace TraktNET
{
    internal sealed class TestHttpClientProvider : HttpClientProvider<TraktContext>, IDisposable
    {
        private const string AcceptMediaType = "application/json";
        private const string TraktApiHeaderKey = "trakt-api-key";
        private const string TraktApiVersionHeaderKey = "trakt-api-version";
        private const string TraktApiAuthorizationHeaderKey = "Authorization";

        private const uint DefaultPage = 1;
        private const uint DefaultPageCount = 1;
        private const uint DefaultLimit = 10;
        private const uint DefaultItemCount = 10;

        private readonly MockHttpMessageHandler _mockHttpMessageHandler;
        private readonly string _baseUrl;

        public TestHttpClientProvider(string baseUrl)
        {
            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new ArgumentException("invalid base URL", nameof(baseUrl));
            }

            _mockHttpMessageHandler = new MockHttpMessageHandler();
            _baseUrl = baseUrl;
        }

        public void SetupMockResponse(string requestUri, string responseContent)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
            {
                throw new ArgumentException("invalid request URI", nameof(requestUri));
            }

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new ArgumentException("invalid response content", nameof(responseContent));
            }

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent, Encoding.UTF8, AcceptMediaType)
            };

            _mockHttpMessageHandler.When(_baseUrl + requestUri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TraktApiHeaderKey, TestConstants.ClientID },
                    { TraktApiVersionHeaderKey, "2" }
                })
                .Respond(_ => response);
        }

        public void SetupMockResponse(string requestUri, string responseContent, uint? page, uint? pageCount, uint? limit, uint? itemCount)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
            {
                throw new ArgumentException("invalid request URI", nameof(requestUri));
            }

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new ArgumentException("invalid response content", nameof(responseContent));
            }

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent, Encoding.UTF8, AcceptMediaType)
            };

            response.Headers.Add(Constants.ResponseHeaders.HEADER_PAGINATION_PAGE_KEY, $"{page ?? DefaultPage}");
            response.Headers.Add(Constants.ResponseHeaders.HEADER_PAGINATION_PAGE_COUNT_KEY, $"{pageCount ?? DefaultPageCount}");
            response.Headers.Add(Constants.ResponseHeaders.HEADER_PAGINATION_LIMIT_KEY, $"{limit ?? DefaultLimit}");
            response.Headers.Add(Constants.ResponseHeaders.HEADER_PAGINATION_ITEM_COUNT_KEY, $"{itemCount ?? DefaultItemCount}");

            _mockHttpMessageHandler.When(_baseUrl + requestUri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TraktApiHeaderKey, TestConstants.ClientID },
                    { TraktApiVersionHeaderKey, "2" }
                })
                .Respond(_ => response);
        }

        public void SetupMockResponse(string requestUri, HttpStatusCode statusCode)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
            {
                throw new ArgumentException("invalid request URI", nameof(requestUri));
            }

            _mockHttpMessageHandler.When(_baseUrl + requestUri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TraktApiHeaderKey, TestConstants.ClientID },
                    { TraktApiVersionHeaderKey, "2" }
                })
                .Respond(statusCode);
        }

        public void SetupOAuthMockResponse(string requestUri, string responseContent, uint? page, uint? pageCount, uint? limit, uint? itemCount)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
            {
                throw new ArgumentException("invalid request URI", nameof(requestUri));
            }

            if (string.IsNullOrWhiteSpace(responseContent))
            {
                throw new ArgumentException("invalid response content", nameof(responseContent));
            }

            var response = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent, Encoding.UTF8, AcceptMediaType)
            };

            response.Headers.Add(Constants.ResponseHeaders.HEADER_PAGINATION_PAGE_KEY, $"{page ?? DefaultPage}");
            response.Headers.Add(Constants.ResponseHeaders.HEADER_PAGINATION_PAGE_COUNT_KEY, $"{pageCount ?? DefaultPageCount}");
            response.Headers.Add(Constants.ResponseHeaders.HEADER_PAGINATION_LIMIT_KEY, $"{limit ?? DefaultLimit}");
            response.Headers.Add(Constants.ResponseHeaders.HEADER_PAGINATION_ITEM_COUNT_KEY, $"{itemCount ?? DefaultItemCount}");

            _mockHttpMessageHandler.When(_baseUrl + requestUri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TraktApiHeaderKey, TestConstants.ClientID },
                    { TraktApiVersionHeaderKey, "2" },
                    { TraktApiAuthorizationHeaderKey, $"Bearer {TestConstants.MockAuthorization.AccessToken}" }
                })
                .Respond(_ => response);
        }

        public void SetupOAuthMockResponse(string requestUri, HttpStatusCode statusCode)
        {
            if (string.IsNullOrWhiteSpace(requestUri))
            {
                throw new ArgumentException("invalid request URI", nameof(requestUri));
            }

            _mockHttpMessageHandler.When(_baseUrl + requestUri)
                .WithHeaders(new Dictionary<string, string>
                {
                    { TraktApiHeaderKey, TestConstants.ClientID },
                    { TraktApiVersionHeaderKey, "2" },
                    { TraktApiAuthorizationHeaderKey, $"Bearer {TestConstants.MockAuthorization.AccessToken}" }
                })
                .Respond(statusCode);
        }

        internal override HttpClient GetHttpClient(TraktContext context)
        {
            var httpClient = _mockHttpMessageHandler.ToHttpClient();
            httpClient.BaseAddress = new Uri(_baseUrl);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AcceptMediaType));
            return httpClient;
        }

        public void Dispose() => _mockHttpMessageHandler.Dispose();
    }
}
