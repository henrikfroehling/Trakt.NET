namespace TraktApiSharp.Exceptions
{
    public class TraktExpiredException : TraktException
    {
        public TraktExpiredException() : this("Expired - the tokens have expired, restart the process") { }

        public TraktExpiredException(string message) : base(message) { }
    }
}
