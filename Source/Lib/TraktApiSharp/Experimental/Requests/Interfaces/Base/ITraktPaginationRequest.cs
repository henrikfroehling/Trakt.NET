namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Responses.Interfaces.Base;
    using System.Threading.Tasks;

    internal interface ITraktPaginationRequest<TItem> : ITraktRequest, ITraktSupportsPagination
    {
        Task<ITraktPaginationResponse<TItem>> QueryAsync();
    }
}
