namespace TraktApiSharp.Requests.Handler
{
    using Interfaces.Base;
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktRequestHandler : ITraktPostRequestHandler, ITraktPutRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync(ITraktRequest request);

        Task<TraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType>(ITraktRequest<TContentType> request);

        Task<TraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType>(ITraktRequest<TContentType> request);

        Task<TraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType>(ITraktRequest<TContentType> request);
    }
}
