namespace TraktApiSharp.Experimental.Responses.Interfaces
{
    using System;

    public interface ITraktPagedResponse<TContentType> : ITraktListResponse<TContentType>, ITraktPagedResponseHeaders, IEquatable<ITraktPagedResponse<TContentType>>
    {

    }
}
