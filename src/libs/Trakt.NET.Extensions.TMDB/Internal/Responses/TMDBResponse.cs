using System.Net;
using System.Net.Http.Headers;

namespace TraktNET
{
    public partial class TMDBResponse<TResponseContentType>
    {
        internal static TMDBResponse<TResponseContentType> Create(HttpStatusCode statusCode, TResponseContentType? content,
            HttpResponseHeaders? headers, HttpContentHeaders? contentHeaders)
            => new()
            {
                Headers = headers,
                StatusCode = statusCode,
                Content = content,
                ContentHeaders = contentHeaders
            };
    }
}
