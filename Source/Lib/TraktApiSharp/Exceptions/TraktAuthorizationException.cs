namespace TraktApiSharp.Exceptions
{
    public class TraktAuthorizationException : TraktException
    {
        public TraktAuthorizationException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized;
        }
    }
}
