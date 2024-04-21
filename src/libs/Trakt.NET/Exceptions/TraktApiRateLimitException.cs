namespace TraktNET
{
    /// <summary>Exception, that will be thrown, if there are too many requests during a specific time period.</summary>
    public sealed class TraktApiRateLimitException(HttpMethod httpMethod, HttpRequestMessage requestMessage,
                                                   string? responseContent, Exception? innerException = null)
        : TraktApiException(CreateExceptionMessage(Constants.StatusCodes.RateLimitExceeded), Constants.StatusCodes.RateLimitExceeded,
                            httpMethod, requestMessage, responseContent, innerException)
    {
        // TODO
        ///// <summary>Additional information parameters about the rate limit.</summary>
        //public ITraktRateLimitInfo RateLimitInfo { get; internal set; }

        /// <summary>Amount of time in seconds after which a retry is possible.</summary>
        public int? RetryAfter { get; internal set; }
    }
}
