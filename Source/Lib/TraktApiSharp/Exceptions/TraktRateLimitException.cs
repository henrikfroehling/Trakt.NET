namespace TraktApiSharp.Exceptions
{
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
        public TraktRateLimitException(string message) : base(message) { }
    }
}
