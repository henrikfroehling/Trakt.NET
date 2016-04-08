namespace TraktApiSharp.Exceptions
{
    public class TraktSeasonNotFoundException : TraktObjectNotFoundException
    {
        public TraktSeasonNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
