namespace TraktApiSharp.Exceptions
{
    public class TraktDeniedException : TraktException
    {
        public TraktDeniedException() : this("Denied - user explicitly denied this code") { }

        public TraktDeniedException(string message) : base(message) { }
    }
}
