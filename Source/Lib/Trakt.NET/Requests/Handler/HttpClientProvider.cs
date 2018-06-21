namespace TraktNet.Requests.Handler
{
    using Core;
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;

    public class HttpClientProvider : IHttpClientProvider
    {
        protected readonly MediaTypeWithQualityHeaderValue MEDIA_TYPE_HEADER = new MediaTypeWithQualityHeaderValue(Constants.MEDIA_TYPE);
        protected static readonly IDictionary<string, HttpClient> s_httpClientCache = new ConcurrentDictionary<string, HttpClient>();
        protected readonly TraktClient _client;

        public HttpClientProvider(TraktClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public virtual HttpClient GetHttpClient()
        {
            if (s_httpClientCache.TryGetValue(_client.ClientId, out HttpClient httpClient))
                return httpClient;

            httpClient = SetupHttpClient();
            s_httpClientCache[_client.ClientId] = httpClient;

            return httpClient;
        }

        private HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient();
            SetDefaultRequestHeaders(httpClient);
            return httpClient;
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(MEDIA_TYPE_HEADER);
            httpClient.DefaultRequestHeaders.Add(Constants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");
            httpClient.DefaultRequestHeaders.Add(Constants.APIClientIdHeaderKey, _client.ClientId);
        }
    }
}
