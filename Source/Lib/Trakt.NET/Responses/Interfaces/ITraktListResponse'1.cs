namespace TraktNet.Responses.Interfaces
{
    using System.Collections.Generic;

    /// <summary>A Trakt list response with items of content type <typeparamref name="TResponseContentType" />.</summary>
    /// <typeparam name="TResponseContentType">The content type of the list items.</typeparam>
    public interface ITraktListResponse<TResponseContentType> : ITraktResponse<IEnumerable<TResponseContentType>>, IEnumerable<TResponseContentType>
    {
    }
}
