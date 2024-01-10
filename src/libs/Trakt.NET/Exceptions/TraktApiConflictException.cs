namespace TraktNET
{
    public sealed class TraktApiConflictException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                  string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Conflict), Constants.StatusCodes.Conflict,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
