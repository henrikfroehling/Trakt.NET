namespace TraktApiSharp.Requests.Handler
{
    using Base;
    using System;
    using System.Net.Http;

    internal sealed class TraktHttpRequestMessage : HttpRequestMessage
    {
        internal TraktHttpRequestMessage() { }

        internal TraktHttpRequestMessage(HttpMethod method, string requestUri) : base(method, requestUri) { }

        internal TraktHttpRequestMessage(HttpMethod method, Uri requestUri) : base(method, requestUri) { }

        public string ObjectId { get; set; }

        internal uint? SeasonNumber { get; set; }

        internal uint? EpisodeNumber { get; set; }

        public string Url { get; set; }

        public TraktRequestObjectType? RequestObjectType { get; set; }

        public string RequestBodyJson { get; set; }
    }
}
