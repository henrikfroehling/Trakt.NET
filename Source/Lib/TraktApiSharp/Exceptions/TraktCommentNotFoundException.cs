namespace TraktApiSharp.Exceptions
{
    public class TraktCommentNotFoundException : TraktObjectNotFoundException
    {
        public TraktCommentNotFoundException(string objectId) : this("Comment Not Found - method exists, but no record found", objectId) { }

        public TraktCommentNotFoundException(string message, string objectId) : base(message, objectId) { }
    }
}
