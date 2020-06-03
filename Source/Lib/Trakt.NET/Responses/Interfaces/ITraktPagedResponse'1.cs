namespace TraktNet.Responses.Interfaces
{
    /// <summary>A Trakt paged list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public interface ITraktPagedResponse<TResponseContentType> : ITraktListResponse<TResponseContentType>, ITraktPagedResponseHeaders
    {
    }
}
