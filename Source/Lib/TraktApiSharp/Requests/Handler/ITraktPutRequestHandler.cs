namespace TraktApiSharp.Requests.Handler
{
    using Interfaces.Base;
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPutRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(ITraktPutRequest<TRequestBodyType> request);

        Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPutRequest<TResponseContentType, TRequestBodyType> request);

        Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPutRequest<TResponseContentType, TRequestBodyType> request);

        Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPutRequest<TResponseContentType, TRequestBodyType> request);
    }
}
