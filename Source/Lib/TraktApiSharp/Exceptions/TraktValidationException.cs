namespace TraktApiSharp.Exceptions
{
    public class TraktValidationException : TraktException
    {
        public TraktValidationException() : this("Unprocessible Entity - validation errors") { }

        public TraktValidationException(string message) : base(message) { }
    }
}
