namespace TraktApiSharp.Exceptions
{
    public class TraktShowNotFoundException : TraktObjectNotFoundException
    {
        public TraktShowNotFoundException(string objectId) : this("Show Not Found - method exists, but no record found", objectId) { }

        public TraktShowNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
