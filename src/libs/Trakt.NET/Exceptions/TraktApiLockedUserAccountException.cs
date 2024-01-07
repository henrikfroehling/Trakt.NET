namespace TraktNET.Exceptions
{
    public sealed class TraktApiLockedUserAccountException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                           string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.LockedUserAccount), Constants.StatusCodes.LockedUserAccount,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
