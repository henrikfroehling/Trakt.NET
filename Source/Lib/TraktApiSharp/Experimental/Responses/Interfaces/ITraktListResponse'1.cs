namespace TraktApiSharp.Experimental.Responses.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ITraktListResponse<TContentType> : ITraktResponse<IEnumerable<TContentType>>, IEnumerable<TContentType>, IEquatable<ITraktListResponse<TContentType>>
    {

    }
}
