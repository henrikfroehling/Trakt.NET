namespace TraktNet.Exceptions
{
    using System.Net;

    /// <summary>Exception, that will be thrown, if OAuth user has locked user account.</summary>
    public class TraktLockedUserAccountException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktLockedUserAccountException" /> class with a default exception message.
        /// </summary>
        public TraktLockedUserAccountException() : this("Locked User Account - OAuth user has locked user account") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktLockedUserAccountException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktLockedUserAccountException(string message) : base(message)
        {
            StatusCode = (HttpStatusCode)423;
        }
    }
}
