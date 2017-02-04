namespace TraktApiSharp.Experimental.Responses.Interfaces
{
    using System;

    public interface ITraktResponse<TContentType> : ITraktNoContentResponse, ITraktResponseHeaders, IEquatable<ITraktResponse<TContentType>>
    {
        bool HasValue { get; }

        TContentType Value { get; }
    }
}
