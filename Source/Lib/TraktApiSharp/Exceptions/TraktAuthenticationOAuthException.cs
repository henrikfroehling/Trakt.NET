namespace TraktApiSharp.Exceptions
{
    public class TraktAuthenticationOAuthException : TraktException
    {
        public TraktAuthenticationOAuthException(string message) : base(message) { }
    }
}
