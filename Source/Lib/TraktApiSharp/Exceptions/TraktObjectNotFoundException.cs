namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Exception, that will be thrown, if an object was not found.<para />
    /// Base class for all object based <see cref="TraktNotFoundException" />s. In this case, objects are comments, episodes, lists, movies, persons, seasons and shows.<para /> 
    /// Contains, additional to the basic information, the object id of the object, which was not found.
    /// </summary>
    public class TraktObjectNotFoundException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktObjectNotFoundException" /> class with a default exception message.
        /// </summary>
        /// <param name="objectId">The id of the object, which was not found.</param>
        public TraktObjectNotFoundException(string objectId) : this("Object Not Found - method exists, but no record found", objectId) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktObjectNotFoundException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="objectId">The id of the object, which was not found.</param>
        public TraktObjectNotFoundException(string message, string objectId) : base(message)
        {
            ObjectId = objectId;
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }

        /// <summary>Gets or sets the object id of the object, which was not found.</summary>
        public string ObjectId { get; set; }
    }
}
