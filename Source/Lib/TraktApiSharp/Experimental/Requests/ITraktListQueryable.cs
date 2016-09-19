namespace TraktApiSharp.Experimental.Requests
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktListQueryable<TItem>
    {
        Task<TraktListResponse<TItem>> QueryAsync();
    }
}
