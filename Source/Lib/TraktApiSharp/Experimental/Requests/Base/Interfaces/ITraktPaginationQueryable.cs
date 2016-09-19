namespace TraktApiSharp.Experimental.Requests.Base.Interfaces
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPaginationQueryable<TItem>
    {
        Task<TraktPaginationResponse<TItem>> QueryAsync();
    }
}
