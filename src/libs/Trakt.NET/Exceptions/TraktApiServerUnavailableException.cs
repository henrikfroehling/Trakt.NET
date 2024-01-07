namespace TraktNET.Exceptions
{
    public sealed class TraktApiServerUnavailableException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                           string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailable), Constants.StatusCodes.ServiceUnavailable,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
