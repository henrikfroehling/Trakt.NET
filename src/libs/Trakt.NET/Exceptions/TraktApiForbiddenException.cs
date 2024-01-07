namespace TraktNET.Exceptions
{
    public sealed class TraktApiForbiddenException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                   string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Forbidden), Constants.StatusCodes.Forbidden,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
