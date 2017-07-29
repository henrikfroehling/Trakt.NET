namespace TraktApiSharp.Responses.Interfaces
{
    public interface ITraktPagedResponse<TResponseContentType> : ITraktListResponse<TResponseContentType>, ITraktPagedResponseHeaders
    {

    }
}
