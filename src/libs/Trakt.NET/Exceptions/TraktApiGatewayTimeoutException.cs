namespace TraktNET
{
    public sealed class TraktApiGatewayTimeoutException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                        string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailableGatewayTimeout), Constants.StatusCodes.ServiceUnavailableGatewayTimeout,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
