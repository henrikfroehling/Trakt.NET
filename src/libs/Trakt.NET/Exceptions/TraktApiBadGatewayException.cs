namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is a bad response at an intermediate proxy server.</summary>
    public sealed class TraktApiBadGatewayException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailableBadGateway), Constants.StatusCodes.ServiceUnavailableBadGateway,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
