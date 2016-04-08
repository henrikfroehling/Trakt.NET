namespace TraktApiSharp.Exceptions
{
    public class TraktAuthorizationException : TraktException
    {
        public TraktAuthorizationException() : this("Unauthorized - OAuth must be provided") { }

        public TraktAuthorizationException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Unauthorized;
        }
    }
}
