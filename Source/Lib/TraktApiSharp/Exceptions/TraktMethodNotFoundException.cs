namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if a method is not allowed or not existing.</summary>
    public class TraktMethodNotFoundException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMethodNotFoundException" /> class with a default exception message.
        /// </summary>
        public TraktMethodNotFoundException() : this("Method Not Found - method doesn't exist") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktMethodNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktMethodNotFoundException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.MethodNotAllowed;
        }
    }
}
