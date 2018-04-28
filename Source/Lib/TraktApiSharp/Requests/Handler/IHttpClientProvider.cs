namespace TraktApiSharp.Requests.Handler
{
    using System.Net.Http;

    public interface IHttpClientProvider
    {
        HttpClient GetHttpClient();

        HttpClient GetAuthorizationHttpClient(string accessToken = null, string clientId = null);
    }
}
