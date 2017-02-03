namespace TraktApiSharp.Experimental.Requests.Interfaces
{
    using Interfaces.Base;
    using Responses.Interfaces;
    using System.Threading.Tasks;

    internal interface ITraktRequestHandler
    {
        // get requests

        Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync(ITraktRequest request);

        Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType>(ITraktRequest<TContentType> request);

        Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType>(ITraktRequest<TContentType> request);

        Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType>(ITraktRequest<TContentType> request);

        // post requests

        Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPostRequest<TRequestBody> request);

        Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request);

        Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request);

        Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request);

        // put requests

        Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPutRequest<TRequestBody> request);

        Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);

        Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);

        Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request);
    }
}
