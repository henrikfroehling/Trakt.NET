namespace TraktNet.Responses.Interfaces
{
    public interface ITraktResponse<TResponseContentType> : ITraktNoContentResponse, ITraktResponseHeaders
    {
        bool HasValue { get; }

        TResponseContentType Value { get; }
    }
}
