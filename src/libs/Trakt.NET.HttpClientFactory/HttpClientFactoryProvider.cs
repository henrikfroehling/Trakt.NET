namespace TraktNET
{
    internal sealed class HttpClientFactoryProvider(IHttpClientFactory httpClientFactory) : HttpClientProvider<TraktContext>
    {
        internal override HttpClient GetHttpClient(TraktContext context) => httpClientFactory.CreateClient(context.ID);
    }
}
