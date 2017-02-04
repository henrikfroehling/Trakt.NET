namespace TraktApiSharp.Experimental.Requests.Handler
{
    using Interfaces.Base;
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPostRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPostRequest<TRequestBody> request);

        Task<TraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request);

        Task<TraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request);

        Task<TraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request);
    }
}
