using System.Net;

namespace TraktNET
{
    /// <summary>
    /// Base class for all Trakt.NET API exceptions.<para />
    /// Can contain additional information like the response's status code, the request's url, a reason phrase of the server,
    /// the request body, if it was a post or put request and the actual response content.
    /// </summary>
    public partial class TraktApiException : TraktException
    {
        /// <summary>Response HTTP status code.</summary>
        public HttpStatusCode StatusCode { get; }

        /// <summary>The server's reason phrase.</summary>
        public string? ReasonPhrase { get; }

        /// <summary>Request HTTP method.</summary>
        public HttpMethod HttpMethod { get; }

        /// <summary><see cref="Uri"/> used to send the request.</summary>
        public Uri? RequestUrl => RequestMessage.RequestUri;

        /// <summary>Request message used to send the request.</summary>
        public HttpRequestMessage RequestMessage { get; }

        /// <summary>HTTP response content as string.</summary>
        public string? ResponseContent { get; }
    }
}
