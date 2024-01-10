namespace TraktNET
{
    public class TraktApiNotFoundException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                           string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.NotFound), Constants.StatusCodes.NotFound,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
