namespace TraktApiSharp.Requests.Handler
{
    using Core;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    internal static class ResponseMessageHelper
    {
        internal static async Task<Stream> GetResponseContentStreamAsync(HttpResponseMessage responseMessage)
        {
            Stream responseContentStream = responseMessage.Content != null ? await responseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false) : default;
            DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);
            return responseContentStream;
        }
    }
}
