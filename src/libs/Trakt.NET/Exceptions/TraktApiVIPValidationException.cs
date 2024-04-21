namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if the authorized user does not have VIP support.</summary>
    public sealed class TraktApiVIPValidationException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                       string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.VIPOnly), Constants.StatusCodes.VIPOnly,
                            httpMethod, requestMessage, responseContent, innerException)
    {
        /// <summary>URL where the user can sign up for Trakt VIP.</summary>
        public string? UpgradeURL { get; internal set; }
    }
}
