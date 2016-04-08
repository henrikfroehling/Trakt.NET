namespace TraktApiSharp.Exceptions
{
    public class TraktBadRequestException : TraktException
    {
        public TraktBadRequestException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
