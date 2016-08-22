namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if an access token is required, but was not provided.</summary>
    public class TraktAuthorizationException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAuthorizationException" /> class with a default exception message.
        /// </summary>
        public TraktAuthorizationException() : this("Unauthorized - OAuth must be provided") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAuthorizationException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktAuthorizationException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized;
        }
    }
}
