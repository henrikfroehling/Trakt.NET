namespace TraktApiSharp.Exceptions
{
    public class TraktNotFoundException : TraktException
    {
        public TraktNotFoundException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}
