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
        private readonly MediaTypeWithQualityHeaderValue MEDIA_TYPE_HEADER = new MediaTypeWithQualityHeaderValue(MEDIA_TYPE);
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

        public HttpClient GetAuthorizationHttpClient(string accessToken = null, string clientId = null)
        {
            string authorizationClientIdKey = $"{_client.ClientId}-AUTH";

            if (s_httpClientCache.TryGetValue(authorizationClientIdKey, out HttpClient httpClient))
                return httpClient;

            httpClient = SetupAuthorizationHttpClient(accessToken, clientId);
            s_httpClientCache[authorizationClientIdKey] = httpClient;

            return httpClient;
        }

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient();
            SetDefaultRequestHeaders(httpClient);
            return httpClient;
        }

        private HttpClient SetupAuthorizationHttpClient(string accessToken = null, string clientId = null)
        {
            var httpClient = new HttpClient();
            SetAuthorizationRequestHeaders(httpClient, accessToken ?? _client.Authorization.AccessToken, clientId ?? _client.ClientId);
            return httpClient;
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(MEDIA_TYPE_HEADER);
            httpClient.DefaultRequestHeaders.Add(Constants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");
            httpClient.DefaultRequestHeaders.Add(Constants.APIClientIdHeaderKey, _client.ClientId);
        }

        private void SetAuthorizationRequestHeaders(HttpClient httpClient, string accessToken, string clientId)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(MEDIA_TYPE_HEADER);
            httpClient.DefaultRequestHeaders.Add(Constants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");
            httpClient.DefaultRequestHeaders.Add(Constants.APIClientIdHeaderKey, clientId);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_TYPE, accessToken);
        }
    }
}
