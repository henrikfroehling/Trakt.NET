namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktListRequest<TItem> : ITraktRequest
    {
        Task<TraktListResponse<TItem>> QueryAsync();
    }
}
