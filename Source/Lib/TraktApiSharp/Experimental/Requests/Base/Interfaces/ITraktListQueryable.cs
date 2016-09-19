namespace TraktApiSharp.Experimental.Requests.Base.Interfaces
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktListQueryable<TItem>
    {
        Task<TraktListResponse<TItem>> QueryAsync();
    }
}
