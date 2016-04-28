namespace TraktApiSharp.Exceptions
{
    public class TraktListNotFoundException : TraktObjectNotFoundException
    {
        public TraktListNotFoundException(string objectId) : this("List Not Found - method exists, but no record found", objectId) { }

        public TraktListNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
