namespace TraktApiSharp.Exceptions
{
    public class TraktResourceAlreadyCreatedException : TraktException
    {
        public TraktResourceAlreadyCreatedException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.Conflict;
        }
    }
}
