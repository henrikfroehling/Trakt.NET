namespace TraktApiSharp.Experimental.Requests.Handler
{
    using Interfaces.Base;
    using Responses.Interfaces;
    using System.Threading.Tasks;

    internal interface ITraktRequestHandler : ITraktPostRequestHandler, ITraktPutRequestHandler
    {
        Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync(ITraktRequest request);

        Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType>(ITraktRequest<TContentType> request);

        Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType>(ITraktRequest<TContentType> request);

        Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType>(ITraktRequest<TContentType> request);
    }
}
