namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if an OAuth user has a locked user account.</summary>
    public sealed class TraktApiLockedUserAccountException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                           string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.LockedUserAccount), Constants.StatusCodes.LockedUserAccount,
                            httpMethod, requestMessage, responseContent, innerException)
    {
    }
}
