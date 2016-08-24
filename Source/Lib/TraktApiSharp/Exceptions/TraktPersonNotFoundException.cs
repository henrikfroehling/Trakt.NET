namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if a person was not found.<para />
    /// Contains, additional to the basic information, the person id of the person, which was not found.
    /// </summary>
    public class TraktPersonNotFoundException : TraktObjectNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktPersonNotFoundException" /> class with a default exception message.
        /// </summary>
        /// <param name="personId">The Trakt-Id or -Slug of the person, which was not found.</param>
        public TraktPersonNotFoundException(string personId) : this("Person Not Found - method exists, but no record found", personId) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktPersonNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="personId">The Trakt-Id or -Slug of the person, which was not found.</param>
        public TraktPersonNotFoundException(string message, string personId) : base(message, personId) { }
    }
}
