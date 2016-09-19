namespace TraktApiSharp.Experimental.Requests
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPaginationQueryable<TItem>
    {
        Task<TraktPaginationResponse<TItem>> QueryAsync();
    }
}
