namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an access token is required, but was not provided.</summary>
    public sealed class TraktApiAuthorizationException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                       string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Unauthorized), Constants.StatusCodes.Unauthorized,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
