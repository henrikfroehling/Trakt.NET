namespace TraktApiSharp.Exceptions
{
    public class TraktMethodNotFoundException : TraktException
    {
        public TraktMethodNotFoundException() : this("Method Not Found - method doesn't exist") { }

        public TraktMethodNotFoundException(string message) : base(message)
        {
            StatusCode = System.Net.HttpStatusCode.MethodNotAllowed;
        }
    }
}
