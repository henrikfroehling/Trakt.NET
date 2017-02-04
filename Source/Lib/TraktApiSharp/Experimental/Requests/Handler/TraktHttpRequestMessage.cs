namespace TraktApiSharp.Experimental.Requests.Handler
{
    using System;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal sealed class TraktHttpRequestMessage : HttpRequestMessage
    {
        internal TraktHttpRequestMessage() { }

        internal TraktHttpRequestMessage(HttpMethod method, string requestUri) : base(method, requestUri) { }

        internal TraktHttpRequestMessage(HttpMethod method, Uri requestUri) : base(method, requestUri) { }

        public string Id { get; set; }

        internal uint? SeasonNumber { get; set; }

        internal uint? EpisodeNumber { get; set; }

        public string Url { get; set; }

        public TraktRequestObjectType? RequestObjectType { get; set; }

        public string RequestBodyJson { get; set; }
    }
}
