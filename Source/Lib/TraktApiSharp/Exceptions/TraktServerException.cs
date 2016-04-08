namespace TraktApiSharp.Exceptions
{
    public class TraktServerException : TraktException
    {
        public TraktServerException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.InternalServerError;
        }
    }
}
