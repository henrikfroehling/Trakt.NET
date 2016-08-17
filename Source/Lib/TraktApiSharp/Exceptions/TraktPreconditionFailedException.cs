namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if the request parameters are not valid.</summary>
    public class TraktPreconditionFailedException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktPreconditionFailedException" /> class with a default exception message.
        /// </summary>
        public TraktPreconditionFailedException() : this("Precondition Failed - use application/json content type") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktPreconditionFailedException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktPreconditionFailedException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.PreconditionFailed;
        }
    }
}
