namespace TraktNet.Responses.Interfaces
{
    /// <summary>A Trakt response with content of type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type.</typeparam>
    public interface ITraktResponse<out TResponseContentType> : ITraktNoContentResponse, ITraktResponseHeaders
    {
        /// <summary>Gets, whether this response has a content value set.</summary>
        bool HasValue { get; }

        /// <summary>Gets the set content value of this response.</summary>
        TResponseContentType Value { get; }
    }
}
