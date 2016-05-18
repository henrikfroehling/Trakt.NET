namespace TraktApiSharp.Exceptions
{
    using System;

    public class TraktCheckinException : TraktException
    {
        public TraktCheckinException(string message) : base(message) { }

        public DateTime? ExpiresAt { get; set; }
    }
}
