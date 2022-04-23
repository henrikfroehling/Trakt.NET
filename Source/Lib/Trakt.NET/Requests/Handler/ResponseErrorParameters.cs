﻿namespace TraktNet.Requests.Handler
{
    using Base;
    using Responses.Interfaces;
    using System.Net;

    internal sealed class ResponseErrorParameters
    {
        internal ResponseErrorParameters() => Headers = new ResponseErrorHeaders();

        public string Url { get; set; }

        public string RequestBody { get; set; }

        public string ResponseBody { get; set; }

        public string ServerReasonPhrase { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public RequestObjectType RequestObjectType { get; set; }

        public string ObjectId { get; set; }

        public uint SeasonNumber { get; set; }

        public uint EpisodeNumber { get; set; }

        public bool IsCheckinRequest { get; set; }

        public bool IsDeviceRequest { get; set; }

        public bool IsInAuthorizationPolling { get; set; }

        public bool IsAuthorizationRequest { get; set; }

        public bool IsAuthorizationRevoke { get; set; }

        public ITraktPagedResponseHeaders Headers { get; set; }
    }
}
