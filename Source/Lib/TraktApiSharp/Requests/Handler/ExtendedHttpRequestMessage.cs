namespace TraktApiSharp.Requests.Handler
{
    using Base;
    using System;
    using System.Net.Http;

    internal sealed class ExtendedHttpRequestMessage : HttpRequestMessage
    {
        internal ExtendedHttpRequestMessage() { }

        internal ExtendedHttpRequestMessage(HttpMethod method, string requestUri) : base(method, requestUri) { }

        internal ExtendedHttpRequestMessage(HttpMethod method, Uri requestUri) : base(method, requestUri) { }

        public string ObjectId { get; set; }

        internal uint? SeasonNumber { get; set; }

        internal uint? EpisodeNumber { get; set; }

        public string Url { get; set; }

        public RequestObjectType? RequestObjectType { get; set; }

        public string RequestBodyJson { get; set; }
    }
}
