namespace TraktApiSharp.Exceptions
{
    public class TraktPersonNotFoundException : TraktObjectNotFoundException
    {
        public TraktPersonNotFoundException(string objectId) : this("Person Not Found - method exists, but no record found", objectId) { }

        public TraktPersonNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
