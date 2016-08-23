namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if there is an error on the server side.</summary>
    public class TraktServerException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktServerException" /> class with a default exception message.
        /// </summary>
        public TraktServerException() : this("Server Error") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktServerException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktServerException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.InternalServerError;
        }
    }
}
