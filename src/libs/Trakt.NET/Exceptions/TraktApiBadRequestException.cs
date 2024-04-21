namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there is an unknown error for the request.</summary>
    public sealed class TraktApiBadRequestException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.BadRequest), Constants.StatusCodes.BadRequest,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
