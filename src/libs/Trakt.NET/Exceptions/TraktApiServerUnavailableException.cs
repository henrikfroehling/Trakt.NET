namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the server is unavailable.</summary>
    public sealed class TraktApiServerUnavailableException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                           string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServiceUnavailable), Constants.StatusCodes.ServiceUnavailable,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
