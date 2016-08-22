namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if there is an unknown error for the request.</summary>
    public class TraktBadRequestException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktBadRequestException" /> class with a default exception message.
        /// </summary>
        public TraktBadRequestException() : this("Bad Request - request couldn't be parsed") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktBadRequestException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktBadRequestException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
