namespace TraktApiSharp.Exceptions
{
    public class TraktForbiddenException : TraktException
    {
        public TraktForbiddenException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Forbidden;
        }
    }
}
