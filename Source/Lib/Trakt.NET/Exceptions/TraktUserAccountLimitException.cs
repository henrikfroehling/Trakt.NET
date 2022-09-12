namespace TraktNet.Exceptions
{
    using System.Net;

    /// <summary>Exception, that will be thrown, if a user has exceeded their account limits.</summary>
    public class TraktUserAccountLimitException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktUserAccountLimitException" /> class with a default exception message.
        /// </summary>
        public TraktUserAccountLimitException() : this("Exceeded account limit - user has exceeded their account limit") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktUserAccountLimitException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktUserAccountLimitException(string message) : base(message)
        {
            StatusCode = (HttpStatusCode)420;
        }

        /// <summary>The web URL where the user can sign up for Trakt VIP.</summary>
        public string UpgradeURL { get; internal set; }

        /// <summary>Determines whether the user is a VIP user.</summary>
        public bool? IsVIPUser { get; internal set; }

        /// <summary>The user's account limit.</summary>
        public int? AccountLimit { get; internal set; }
    }
}
