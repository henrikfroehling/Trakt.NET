namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the request parameters are not valid.</summary>
    public sealed class TraktApiPreconditionFailedException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                            string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.PreconditionFailed), Constants.StatusCodes.PreconditionFailed,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
