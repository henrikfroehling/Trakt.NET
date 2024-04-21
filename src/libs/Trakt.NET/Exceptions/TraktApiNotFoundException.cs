namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if no result(s) was(were) found for a request.</summary>
    public class TraktApiNotFoundException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                           string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.NotFound), Constants.StatusCodes.NotFound,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
