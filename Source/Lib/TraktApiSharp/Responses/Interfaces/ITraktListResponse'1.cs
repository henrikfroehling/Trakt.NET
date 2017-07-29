namespace TraktApiSharp.Responses.Interfaces
{
    using System.Collections.Generic;

    public interface ITraktListResponse<TResponseContentType> : ITraktResponse<IEnumerable<TResponseContentType>>, IEnumerable<TResponseContentType>
    {

    }
}
