namespace TraktApiSharp.Exceptions
{
    public class TraktServerUnavailableException : TraktException
    {
        public TraktServerUnavailableException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
        }
    }
}
