namespace TraktNet.Requests.Handler
{
    using System.Net.Http;

    public interface IHttpClientProvider
    {
        HttpClient GetHttpClient(string clientId);
    }
}
