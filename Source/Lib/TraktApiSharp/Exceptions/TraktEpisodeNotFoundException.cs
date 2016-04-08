namespace TraktApiSharp.Exceptions
{
    public class TraktEpisodeNotFoundException : TraktObjectNotFoundException
    {
        public TraktEpisodeNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
