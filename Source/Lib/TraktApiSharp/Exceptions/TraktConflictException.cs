namespace TraktApiSharp.Exceptions
{
    public class TraktConflictException : TraktException
    {
        public TraktConflictException() : this("Conflict - resource already created") { }

        public TraktConflictException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Conflict;
        }
    }
}
