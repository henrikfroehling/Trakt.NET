namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if the server is unavailable.</summary>
    public class TraktServerUnavailableException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktServerUnavailableException" /> class with a default exception message.
        /// </summary>
        public TraktServerUnavailableException() : this("Service Unavailable - server overloaded (try again in 30s)") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktServerUnavailableException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktServerUnavailableException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
        }
    }
}
