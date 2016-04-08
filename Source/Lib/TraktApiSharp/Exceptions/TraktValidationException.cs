namespace TraktApiSharp.Exceptions
{
    public class TraktValidationException : TraktException
    {
        public TraktValidationException(string message) : base(message) { }
    }
}
