using System.Net;

namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is an error on the Cloudflare server side.</summary>
    public sealed class TraktApiCloudflareException(HttpStatusCode httpStatusCode, HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(httpStatusCode), httpStatusCode, httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
