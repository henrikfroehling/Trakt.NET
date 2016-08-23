namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if there is an error during authentication.</summary>
    public class TraktAuthenticationException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAuthenticationException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktAuthenticationException(string message) : base(message) { }
    }
}
