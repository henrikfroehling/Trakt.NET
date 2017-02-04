namespace TraktApiSharp.Experimental.Responses.Interfaces
{
    using System.Collections.Generic;

    public interface ITraktListResponse<TContentType> : ITraktResponse<IEnumerable<TContentType>>, IEnumerable<TContentType>
    {

    }
}
