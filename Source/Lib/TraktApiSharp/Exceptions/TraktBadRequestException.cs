namespace TraktApiSharp.Exceptions
{
    public class TraktBadRequestException : TraktException
    {
        public TraktBadRequestException() : this("Bad Request - request couldn't be parsed") { }

        public TraktBadRequestException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
    }
}
