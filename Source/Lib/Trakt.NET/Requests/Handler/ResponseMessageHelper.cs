namespace TraktNet.Requests.Handler
{
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal static class ResponseMessageHelper
    {
        internal static async Task<Stream> GetResponseContentStreamAsync(HttpResponseMessage responseMessage)
            => responseMessage.Content != null ? await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false) : default;

        internal static async Task<string> GetResponseContentAsync(HttpResponseMessage responseMessage)
            => responseMessage.Content != null ? await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false) : string.Empty;
    }
}
