namespace TraktApiSharp.Exceptions
{
    /// <summary>
    /// Base class for all object based TraktNotFoundExceptions. In this case, objects are comments, episodes, lists, movies, persons, seasons and shows.<para /> 
    /// Contains, additional to the basic information, the object id of the object, which was not found.
    /// </summary>
    public class TraktObjectNotFoundException : TraktException
    {
        public TraktObjectNotFoundException(string objectId) : this("Object Not Found - method exists, but no record found", objectId) { }

        public TraktObjectNotFoundException(string message, string objectId) : base(message)
        {
            ObjectId = objectId;
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }

        /// <summary>Gets or sets the object id of the object, which was not found.</summary>
        public string ObjectId { get; set; }
    }
}
