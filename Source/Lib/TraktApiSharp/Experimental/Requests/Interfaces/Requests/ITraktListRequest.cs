namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktListRequest<TItem>
    {
        Task<TraktListResponse<TItem>> QueryAsync();
    }
}
