namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is an error on the server side.</summary>
    public sealed class TraktApiServerException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServerError), Constants.StatusCodes.ServerError,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
