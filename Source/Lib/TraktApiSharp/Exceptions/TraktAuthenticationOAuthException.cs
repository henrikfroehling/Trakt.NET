namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if there is an error during OAuth authentication.</summary>
    public class TraktAuthenticationOAuthException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAuthenticationOAuthException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktAuthenticationOAuthException(string message) : base(message) { }
    }
}
