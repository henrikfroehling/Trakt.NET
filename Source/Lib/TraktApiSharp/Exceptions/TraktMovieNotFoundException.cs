namespace TraktApiSharp.Exceptions
{
    public class TraktMovieNotFoundException : TraktObjectNotFoundException
    {
        public TraktMovieNotFoundException(string objectId) : this("Movie Not Found - method exists, but no record found", objectId) { }

        public TraktMovieNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
