namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktListRequest<TItem>
    {
        Task<TraktListResponse<TItem>> QueryAsync();
    }
}
