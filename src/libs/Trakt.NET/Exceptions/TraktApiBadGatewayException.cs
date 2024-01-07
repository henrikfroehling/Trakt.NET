namespace TraktNET.Exceptions
{
    public sealed class TraktApiBadGatewayException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailableBadGateway), Constants.StatusCodes.ServiceUnavailableBadGateway,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
