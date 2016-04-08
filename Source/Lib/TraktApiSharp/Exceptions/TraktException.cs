namespace TraktApiSharp.Exceptions
{
    using System;
    using System.Net;

    public abstract class TraktException : Exception
    {
        public TraktException(string message) : base(message) { }

        public override string Message => base.Message;

        public HttpStatusCode StatusCode { get; protected set; }

        public string RequestUrl { get; set; }

        public string RequestBody { get; set; }
    }
}
