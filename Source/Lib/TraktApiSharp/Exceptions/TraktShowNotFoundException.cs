namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if a show was not found.<para />
    /// Contains, additional to the basic information, the show id of the show, which was not found.
    /// </summary>
    public class TraktShowNotFoundException : TraktObjectNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktShowNotFoundException" /> class with a default exception message.
        /// </summary>
        /// <param name="showId">The Trakt-Id or -Slug of the show, which was not found.</param>
        public TraktShowNotFoundException(string showId) : this("Show Not Found - method exists, but no record found", showId) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktShowNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="showId">The Trakt-Id or -Slug of the show, which was not found.</param>
        public TraktShowNotFoundException(string message, string showId) : base(message, showId) { }
    }
}
