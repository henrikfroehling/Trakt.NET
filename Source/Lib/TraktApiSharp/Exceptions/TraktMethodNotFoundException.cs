namespace TraktApiSharp.Exceptions
{
    public class TraktMethodNotFoundException : TraktException
    {
        public TraktMethodNotFoundException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.MethodNotAllowed;
        }
    }
}
