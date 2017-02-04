namespace TraktApiSharp.Experimental.Responses.Interfaces
{
    public interface ITraktResponse<TContentType> : ITraktNoContentResponse, ITraktResponseHeaders
    {
        bool HasValue { get; }

        TContentType Value { get; }
    }
}
