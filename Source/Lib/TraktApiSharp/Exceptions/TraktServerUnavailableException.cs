namespace TraktApiSharp.Exceptions
{
    public class TraktServerUnavailableException : TraktException
    {
        public TraktServerUnavailableException() : this("Service Unavailable - server overloaded (try again in 30s)") { }

        public TraktServerUnavailableException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.ServiceUnavailable;
        }
    }
}
