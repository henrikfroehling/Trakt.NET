namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if no result(s) was(were) found for a request.</summary>
    public class TraktNotFoundException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktNotFoundException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}
