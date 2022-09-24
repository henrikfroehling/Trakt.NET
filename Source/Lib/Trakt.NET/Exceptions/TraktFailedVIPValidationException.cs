namespace TraktNet.Exceptions
{
    using System.Net;

    /// <summary>Exception, that will be thrown, if the authorized user does not have VIP support.</summary>
    public class TraktFailedVIPValidationException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktFailedVIPValidationException" /> class with a default exception message.
        /// </summary>
        public TraktFailedVIPValidationException() : this("VIP Only - authorized user does not have VIP support") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktFailedVIPValidationException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktFailedVIPValidationException(string message) : base(message)
        {
            StatusCode = (HttpStatusCode)426;
        }

        /// <summary>The web URL where the user can sign up for Trakt VIP.</summary>
        public string UpgradeURL { get; internal set; }
    }
}
