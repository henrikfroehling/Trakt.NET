namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if there is an error during Device authentication.</summary>
    public class TraktAuthenticationDeviceException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktAuthenticationDeviceException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktAuthenticationDeviceException(string message) : base(message) { }
    }
}
