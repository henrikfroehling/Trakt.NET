namespace TraktApiSharp.Experimental.Responses.Interfaces.Base
{
    public interface ITraktResponse<TContentType> : ITraktNoContentResponse, ITraktResponseHeaders
    {
        bool HasValue { get; }

        TContentType Value { get; }
    }
}
