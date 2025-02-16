#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

using System.Net;
using System.Net.Http.Headers;

namespace TraktNET
{
    /// <summary>A TMDB response with content of type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type.</typeparam>
    public partial class TMDBResponse<TResponseContentType>
    {
        /// <summary>The headers of the response message.</summary>
        public HttpResponseHeaders? Headers { get; internal set; }

        /// <summary>The status code of the response message.</summary>
        public HttpStatusCode StatusCode { get; internal set; }

        /// <summary>Gets, whether the request for this response was successful.</summary>
#if NET6_0_OR_GREATER
        [MemberNotNullWhen(true, nameof(Headers))]
#endif
        public bool IsSuccess => (int)StatusCode >= 200 && (int)StatusCode <= 299;

        /// <summary>Gets, whether this response has a content value set.</summary>
#if NET6_0_OR_GREATER
        [MemberNotNullWhen(true, nameof(Content))]
        [MemberNotNullWhen(true, nameof(ContentHeaders))]
#endif
        public bool HasValue => Content != null;

        /// <summary>The content of the response.</summary>
        public TResponseContentType? Content { get; internal set; }

        /// <summary>The headers of the response messsage content.</summary>
        public HttpContentHeaders? ContentHeaders { get; internal set; }

        /// <summary>Implicit conversion to bool for this response.</summary>
        /// <param name="response">The <see cref="TMDBResponse{TResponseContentType}" /> instance, which will be converted to bool.</param>
        public static implicit operator bool(TMDBResponse<TResponseContentType> response) => response.IsSuccess;
    }
}
