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
        public TraktException(string message) : base(message) { }

        public TraktException(string message, Exception innerException) : base(message, innerException) { }

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
