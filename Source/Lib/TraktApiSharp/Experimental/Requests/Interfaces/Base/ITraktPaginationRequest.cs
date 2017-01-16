namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPaginationRequest<TItem> : ITraktRequest, ITraktPagination
    {
        Task<TraktPaginationResponse<TItem>> QueryAsync();
    }
}
