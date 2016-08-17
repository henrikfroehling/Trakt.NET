namespace TraktApiSharp.Exceptions
{
    using System;
    using System.Net;

    /// <summary>
    /// Base class for all TraktApiSharp exceptions.<para />
    /// Can contain additional information like the response's status code, the request's url, a reason phrase of the server,
    /// the request body, if it was a post or put request and the actual response content.
    /// </summary>
    public class TraktException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TraktException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        public TraktException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="TraktException" /> class with a custom message.
        /// </summary>
        /// <param name="message">A custom exception message.</param>
        /// <param name="innerException">An exception that is the cause of the current exception.</param>
        public TraktException(string message, Exception innerException) : base(message, innerException) { }

        /// <summary>Returns the response's status code.</summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>Gets or sets the request's url.</summary>
        public string RequestUrl { get; set; }

        /// <summary>Gets or sets the request body.</summary>
        public string RequestBody { get; set; }

        /// <summary>Gets or sets the response content.</summary>
        public string Response { get; set; }

        /// <summary>Gets or sets the server reason phrase.</summary>
        public string ServerReasonPhrase { get; set; }
    }
}
