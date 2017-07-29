namespace TraktApiSharp.Requests.Handler
{
    using Interfaces.Base;
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktRequestHandler : ITraktPostRequestHandler, ITraktPutRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync(ITraktRequest request);

        Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType>(ITraktRequest<TResponseContentType> request);

        Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType>(ITraktRequest<TResponseContentType> request);

        Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType>(ITraktRequest<TResponseContentType> request);
    }
}
