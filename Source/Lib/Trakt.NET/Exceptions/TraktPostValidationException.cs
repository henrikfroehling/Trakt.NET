namespace TraktNet.Exceptions
{
    /// <summary>Exception, that will be thrown, if validation of a post object fails.</summary>
    public class TraktPostValidationException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktPostValidationException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktPostValidationException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktPostValidationException" /> class with a custom message.
        /// </summary>
        /// <param name="propertyName">The name of the proeprty that caused the current exception.</param>
        /// <param name="message">A custom exception message.</param>
        public TraktPostValidationException(string propertyName, string message)
            : base(message)
            => PropertyName = propertyName;

        /// <summary>The name of the proeprty that caused the current exception.</summary>
        public string PropertyName { get; set; }

        /// <summary>Gets the message that describes the current exception.</summary>
        public override string Message
        {
            get
            {
                if (!string.IsNullOrEmpty(base.Message))
                    return $"{base.Message}, Property={PropertyName}";

                return $"Property={PropertyName}";
            }
        }
    }
}
