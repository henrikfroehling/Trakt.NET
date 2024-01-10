namespace TraktNET
{
    public sealed class TraktApiAuthorizationException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                       string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Unauthorized), Constants.StatusCodes.Unauthorized,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
