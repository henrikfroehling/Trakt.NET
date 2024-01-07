namespace TraktNET.Exceptions
{
    public sealed class TraktApiPreconditionFailedException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                            string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.PreconditionFailed), Constants.StatusCodes.PreconditionFailed,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
