namespace TraktNet.Exceptions
{
    using Objects.Basic;
    using System.Net;

    /// <summary>Exception, that will be thrown, if there are too many requests during a specific time period.</summary>
    public class TraktRateLimitException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktRateLimitException" /> class with a default exception message.
        /// </summary>
        public TraktRateLimitException() : this("Slow Down - your app is polling too quickly") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktRateLimitException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktRateLimitException(string message) : base(message)
        {
            StatusCode = (HttpStatusCode)429;
        }

        /// <summary>Gets the further info parameters about the rate limit exception.</summary>
        public ITraktRateLimitInfo RateLimitInfo { get; internal set; }

        /// <summary>The amount of time in seconds after which a retry is possible.</summary>
        public int? RetryAfter { get; internal set; }
    }
}
