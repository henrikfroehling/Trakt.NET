namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if the tokens have expired during authentication.</summary>
    public class TraktExpiredException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktExpiredException" /> class with a default exception message.
        /// </summary>
        public TraktExpiredException() : this("Expired - the tokens have expired, restart the process") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktExpiredException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktExpiredException(string message) : base(message) { }
    }
}
