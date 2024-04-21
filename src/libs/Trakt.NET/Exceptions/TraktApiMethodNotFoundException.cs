namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if a method is not allowed or not existing.</summary>
    public sealed class TraktApiMethodNotFoundException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                        string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.MethodNotFound), Constants.StatusCodes.MethodNotFound,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
