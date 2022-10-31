namespace TraktNet.Exceptions
{
    /// <summary>Exception, that will be thrown, if validation of a request object fails.</summary>
    public class TraktRequestValidationException : TraktPostValidationException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktRequestValidationException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktRequestValidationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktRequestValidationException" /> class with a custom message.
        /// </summary>
        /// <param name="propertyName">The name of the proeprty that caused the current exception.</param>
        /// <param name="message">A custom exception message.</param>
        public TraktRequestValidationException(string propertyName, string message) : base(propertyName, message)
        {
        }
    }
}
