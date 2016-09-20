namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPaginationRequest<TItem> : ITraktPagination
    {
        Task<TraktPaginationResponse<TItem>> QueryAsync();
    }
}
