namespace TraktApiSharp.Exceptions
{
    public class TraktAuthenticationException : TraktException
    {
        public TraktAuthenticationException(string message) : base(message) { }
    }
}
