namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if sent data is not valid.</summary>
    public class TraktValidationException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktValidationException" /> class with a default exception message.
        /// </summary>
        public TraktValidationException() : this("Unprocessible Entity - validation errors") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktValidationException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktValidationException(string message) : base(message) { }
    }
}
