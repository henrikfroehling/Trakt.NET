namespace TraktApiSharp.Exceptions
{
    using System;
    using System.Net;

    public class TraktException : Exception
    {
        public TraktException(string message) : base(message) { }

        public TraktException(string message, Exception innerException) : base(message, innerException) { }

        public HttpStatusCode StatusCode { get; internal set; }

        public string RequestUrl { get; set; }

        public string RequestBody { get; set; }

        public string Response { get; set; }

        public string ServerReasonPhrase { get; set; }
    }
}
