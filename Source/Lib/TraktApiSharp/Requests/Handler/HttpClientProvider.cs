namespace TraktApiSharp.Requests.Handler
{
    using Core;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    internal class HttpClientProvider : IHttpClientProvider
    {
        private const string MEDIA_TYPE = "application/json";
        private const string AUTHENTICATION_TYPE = "Bearer";

        private static readonly IDictionary<string, HttpClient> s_httpClientCache = new ConcurrentDictionary<string, HttpClient>();
        private readonly TraktClient _client;

        public HttpClientProvider(TraktClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public HttpClient GetHttpClient()
        {
            if (s_httpClientCache.TryGetValue(_client.ClientId, out HttpClient httpClient))
                return httpClient;

            httpClient = SetupHttpClient();
            s_httpClientCache[_client.ClientId] = httpClient;

            return httpClient;
        }

        public HttpClient GetAuthorizationHttpClient()
        {
            string authorizationClientIdKey = $"{_client.ClientId}-AUTH";

            if (s_httpClientCache.TryGetValue(authorizationClientIdKey, out HttpClient httpClient))
                return httpClient;

            httpClient = SetupAuthorizationHttpClient();
            s_httpClientCache[authorizationClientIdKey] = httpClient;

            return httpClient;
        }

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient();
            SetDefaultRequestHeaders(httpClient);
            return httpClient;
        }

        private HttpClient SetupAuthorizationHttpClient()
        {
            var httpClient = new HttpClient();
            SetAuthorizationRequestHeaders(httpClient);
            return httpClient;
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var mediaTypeHeader = new MediaTypeWithQualityHeaderValue(MEDIA_TYPE);

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(mediaTypeHeader);
            httpClient.DefaultRequestHeaders.Add(Constants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");
            httpClient.DefaultRequestHeaders.Add(Constants.APIClientIdHeaderKey, _client.ClientId);
        }

        private void SetAuthorizationRequestHeaders(HttpClient httpClient)
        {
            var mediaTypeHeader = new MediaTypeWithQualityHeaderValue(MEDIA_TYPE);

            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(mediaTypeHeader);
            httpClient.DefaultRequestHeaders.Add(Constants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");
            httpClient.DefaultRequestHeaders.Add(Constants.APIClientIdHeaderKey, _client.ClientId);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_TYPE, _client.Authorization.AccessToken);
        }
    }
}
