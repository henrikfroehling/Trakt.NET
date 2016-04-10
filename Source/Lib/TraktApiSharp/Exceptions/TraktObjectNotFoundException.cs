namespace TraktApiSharp.Exceptions
{
    public class TraktObjectNotFoundException : TraktException
    {
        public TraktObjectNotFoundException(string objectId) : this("Object Not Found - method exists, but no record found", objectId) { }

        public TraktObjectNotFoundException(string message, string objectId) : base(message)
        {
            ObjectId = objectId;
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }

        public string ObjectId { get; set; }
    }
}
