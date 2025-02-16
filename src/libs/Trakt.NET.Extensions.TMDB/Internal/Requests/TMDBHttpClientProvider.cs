using System.Collections.Concurrent;

namespace TraktNET
{
    internal sealed class TMDBHttpClientProvider : HttpClientProvider<TMDBContext>
    {
        private static readonly ConcurrentDictionary<string, HttpClient> s_httpClientCache = new();

        internal override HttpClient GetHttpClient(TMDBContext context)
            => s_httpClientCache.GetOrAdd(context.ID, CreateHttpClient(context));
    }
}
