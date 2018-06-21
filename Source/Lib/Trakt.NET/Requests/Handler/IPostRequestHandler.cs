namespace TraktNet.Requests.Handler
{
    using Interfaces;
    using Interfaces.Base;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface IPostRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(IPostRequest<TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody;

        Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody;

        Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody;

        Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody;
    }
}
