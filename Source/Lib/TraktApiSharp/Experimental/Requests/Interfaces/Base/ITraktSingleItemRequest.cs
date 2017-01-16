namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Responses.Interfaces.Base;
    using System.Threading.Tasks;

    internal interface ITraktSingleItemRequest<TItem> : ITraktRequest
    {
        Task<ITraktResponse<TItem>> QueryAsync();
    }
}
