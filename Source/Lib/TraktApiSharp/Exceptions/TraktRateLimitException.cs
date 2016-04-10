namespace TraktApiSharp.Exceptions
{
    public class TraktRateLimitException : TraktException
    {
        public TraktRateLimitException() : this("Slow Down - your app is polling too quickly") { }

        public TraktRateLimitException(string message) : base(message) { }
    }
}
