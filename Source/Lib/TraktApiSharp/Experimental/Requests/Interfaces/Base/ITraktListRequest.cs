namespace TraktApiSharp.Experimental.Requests.Interfaces.Base
{
    using Responses.Interfaces.Base;
    using System.Threading.Tasks;

    internal interface ITraktListRequest<TItem> : ITraktRequest
    {
        Task<ITraktListResponse<TItem>> QueryAsync();
    }
}
