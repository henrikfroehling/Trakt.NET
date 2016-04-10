namespace TraktApiSharp.Exceptions
{
    public class TraktBadGatewayException : TraktException
    {
        public TraktBadGatewayException() : this("Bad Gateway") { }

        public TraktBadGatewayException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadGateway;
        }
    }
}
