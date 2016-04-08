namespace TraktApiSharp.Exceptions
{
    public class TraktPreconditionFailedException : TraktException
    {
        public TraktPreconditionFailedException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.PreconditionFailed;
        }
    }
}
