namespace TraktNET
{
    /// <summary>
    /// Exception, that will be thrown, if there is a conflict on the server.
    /// For example, if a resource, e.g. a comment, already exists.
    /// </summary>
    public sealed class TraktApiConflictException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                  string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.Conflict), Constants.StatusCodes.Conflict,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
