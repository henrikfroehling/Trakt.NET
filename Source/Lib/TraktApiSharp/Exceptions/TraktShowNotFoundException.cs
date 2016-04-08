namespace TraktApiSharp.Exceptions
{
    public class TraktShowNotFoundException : TraktObjectNotFoundException
    {
        public TraktShowNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
