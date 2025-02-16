namespace TraktNET
{
    public sealed partial class TMDBRequestValidationException
    {
        internal TMDBRequestValidationException(string message, Exception? innerException = null) : base(message, innerException)
        {
        }

        internal TMDBRequestValidationException(string propertyName, string message, Exception? innerException = null)
            : base(message, innerException)
            => PropertyName = propertyName;
    }
}
