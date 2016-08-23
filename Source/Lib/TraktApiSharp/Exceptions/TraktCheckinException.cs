namespace TraktApiSharp.Exceptions
{
    using System;

    /// <summary>Exception, that will be thrown, if a checkin is already in progress.</summary>
    public class TraktCheckinException : TraktException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktCheckinException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktCheckinException(string message) : base(message) { }

        /// <summary>Gets or sets the UTC datetime, when the current checkin expires and a new checkin can be requested.</summary>
        public DateTime? ExpiresAt { get; set; }
    }
}
