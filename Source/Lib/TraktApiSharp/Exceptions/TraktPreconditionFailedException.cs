namespace TraktApiSharp.Exceptions
{
    public class TraktPreconditionFailedException : TraktException
    {
        public TraktPreconditionFailedException() : this("Precondition Failed - use application/json content type") { }

        public TraktPreconditionFailedException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.PreconditionFailed;
        }
    }
}
