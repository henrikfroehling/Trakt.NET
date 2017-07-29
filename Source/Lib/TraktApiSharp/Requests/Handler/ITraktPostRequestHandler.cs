namespace TraktApiSharp.Requests.Handler
{
    using Interfaces.Base;
    using Responses;
    using System.Threading.Tasks;

    internal interface ITraktPostRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(ITraktPostRequest<TRequestBodyType> request);

        Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPostRequest<TResponseContentType, TRequestBodyType> request);

        Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPostRequest<TResponseContentType, TRequestBodyType> request);

        Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPostRequest<TResponseContentType, TRequestBodyType> request);
    }
}
