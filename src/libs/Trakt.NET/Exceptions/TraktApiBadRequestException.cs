namespace TraktNET
{
    public sealed class TraktApiBadRequestException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                    string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.BadRequest), Constants.StatusCodes.BadRequest,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
