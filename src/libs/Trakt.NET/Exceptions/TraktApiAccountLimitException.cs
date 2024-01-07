namespace TraktNET.Exceptions
{
    public sealed class TraktApiAccountLimitException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                      string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.AccountLimitExceeded), Constants.StatusCodes.AccountLimitExceeded,
                            httpMethod, requestMessage, responseContent, innerException)
    {
        /// <summary>URL where the user can sign up for Trakt VIP.</summary>
        public string? UpgradeURL { get; internal set; }

        /// <summary>User's VIP status.</summary>
        public bool? IsVIPUser { get; internal set; }

        /// <summary>User's account limit.</summary>
        public int? AccountLimit { get; internal set; }
    }
}
