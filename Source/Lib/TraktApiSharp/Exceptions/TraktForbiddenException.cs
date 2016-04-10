namespace TraktApiSharp.Exceptions
{
    public class TraktForbiddenException : TraktException
    {
        public TraktForbiddenException() : this("Forbidden - invalid API key or unapproved app") { }

        public TraktForbiddenException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Forbidden;
        }
    }
}
