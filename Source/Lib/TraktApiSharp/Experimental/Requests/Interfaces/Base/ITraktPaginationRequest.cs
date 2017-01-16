namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPaginationRequest<TItem> : ITraktPagination
    {
        Task<TraktPaginationResponse<TItem>> QueryAsync();
    }
}
