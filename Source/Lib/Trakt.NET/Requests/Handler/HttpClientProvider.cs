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

        public virtual HttpClient GetHttpClient(string clientId)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentException("client id must not be null or empty", nameof(clientId));

            if (s_httpClientCache.TryGetValue(clientId, out HttpClient httpClient))
                return httpClient;

            httpClient = SetupHttpClient();
            s_httpClientCache[clientId] = httpClient;

            return httpClient;
        }

        protected virtual HttpClient SetupHttpClient()
        {
            var httpClient = new HttpClient();
            SetDefaultRequestHeaders(httpClient);
            return httpClient;
        }

        protected virtual void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(MEDIA_TYPE_HEADER);
        }
    }
}
