namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if a list was not found.<para /> 
    /// Contains, additional to the basic information, the list id of the list, which was not found.
    /// </summary>
    public class TraktListNotFoundException : TraktObjectNotFoundException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktListNotFoundException" /> class with a default exception message.
        /// </summary>
        /// <param name="listId">The list id of the list, which was not found.</param>
        public TraktListNotFoundException(string listId) : this("List Not Found - method exists, but no record found", listId) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktListNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="listId">The list id of the list, which was not found.</param>
        public TraktListNotFoundException(string message, string listId) : base(message, listId) { }
    }
}
