namespace TraktApiSharp.Experimental.Requests.Interfaces.Requests
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktSingleItemRequest<TItem>
    {
        Task<TraktResponse<TItem>> QueryAsync();
    }
}
