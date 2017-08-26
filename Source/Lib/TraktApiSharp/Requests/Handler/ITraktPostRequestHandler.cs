namespace TraktApiSharp.Requests.Handler
{
    using Interfaces.Base;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal interface ITraktPostRequestHandler
    {
        Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(IPostRequest<TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken));

        Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken));

        Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken));

        Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken));
    }
}
