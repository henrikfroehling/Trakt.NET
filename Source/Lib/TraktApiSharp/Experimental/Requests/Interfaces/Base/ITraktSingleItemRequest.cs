namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktSingleItemRequest<TItem> : ITraktRequest
    {
        Task<TraktResponse<TItem>> QueryAsync();
    }
}
