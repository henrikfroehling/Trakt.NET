namespace TraktNET.Exceptions
{
    public sealed class TraktApiServerException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.ServerError), Constants.StatusCodes.ServerError,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
