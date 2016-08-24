namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if the request is forbidden.</summary>
    public class TraktForbiddenException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktForbiddenException" /> class with a default exception message.
        /// </summary>
        public TraktForbiddenException() : this("Forbidden - invalid API key or unapproved app") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktForbiddenException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktForbiddenException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Forbidden;
        }
    }
}
