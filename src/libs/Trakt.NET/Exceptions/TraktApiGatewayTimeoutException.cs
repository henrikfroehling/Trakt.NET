namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is an timed out intermediate proxy server while waiting for a response.</summary>
    public sealed class TraktApiGatewayTimeoutException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                        string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailableGatewayTimeout), Constants.StatusCodes.ServiceUnavailableGatewayTimeout,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
