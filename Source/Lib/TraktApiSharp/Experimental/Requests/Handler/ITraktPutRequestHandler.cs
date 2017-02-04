namespace TraktApiSharp.Experimental.Requests.Handler
{
    using Interfaces.Base;
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPutRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPutRequest<TRequestBody> request);

        Task<TraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);

        Task<TraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);

        Task<TraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);
    }
}
