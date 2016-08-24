namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if there is a conflict on server.
    /// For example, if a resource, like comment, already exists.
    /// </summary>
    public class TraktConflictException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktConflictException" /> class with a default exception message.
        /// </summary>
        public TraktConflictException() : this("Conflict - resource already created") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktConflictException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktConflictException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Conflict;
        }
    }
}
