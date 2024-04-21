namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if sent data is not valid.</summary>
    public sealed class TraktApiValidationException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.UnprocessableEntity), Constants.StatusCodes.UnprocessableEntity,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
