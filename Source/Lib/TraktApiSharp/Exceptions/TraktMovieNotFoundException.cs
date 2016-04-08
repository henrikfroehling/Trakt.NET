namespace TraktApiSharp.Exceptions
{
    public class TraktMovieNotFoundException : TraktObjectNotFoundException
    {
        public TraktMovieNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
