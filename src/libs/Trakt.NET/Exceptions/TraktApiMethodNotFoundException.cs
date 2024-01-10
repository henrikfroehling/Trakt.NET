namespace TraktNET
{
    public sealed class TraktApiMethodNotFoundException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                        string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.MethodNotFound), Constants.StatusCodes.MethodNotFound,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
