namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if the user denied the OAuth authentication.</summary>
    public class TraktDeniedException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktDeniedException" /> class with a default exception message.
        /// </summary>
        public TraktDeniedException() : this("Denied - user explicitly denied this code") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktDeniedException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktDeniedException(string message) : base(message) { }
    }
}
