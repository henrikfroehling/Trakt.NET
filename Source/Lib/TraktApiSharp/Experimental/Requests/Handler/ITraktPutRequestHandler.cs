namespace TraktApiSharp.Experimental.Requests.Handler
{
    using Interfaces.Base;
    using Responses.Interfaces;
    using System.Threading.Tasks;

    internal interface ITraktPutRequestHandler
    {
        Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPutRequest<TRequestBody> request);

        Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);

        Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);

        Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);
    }
}
