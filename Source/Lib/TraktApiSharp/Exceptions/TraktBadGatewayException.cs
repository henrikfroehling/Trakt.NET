namespace TraktApiSharp.Exceptions
{
    /// <summary>Exception, that will be thrown, if there is a bad response at an intermediate proxy server.</summary>
    public class TraktBadGatewayException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktBadGatewayException" /> class with a default exception message.
        /// </summary>
        public TraktBadGatewayException() : this("Bad Gateway") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktBadGatewayException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktBadGatewayException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadGateway;
        }
    }
}
