namespace TraktApiSharp.Experimental.Requests
{
    using Interfaces;
    using Interfaces.Base;
    using Responses.Interfaces;
    using System;
    using System.Threading.Tasks;

    internal sealed class TraktRequestHandler : ITraktRequestHandler
    {
        public Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync(ITraktRequest request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType>(ITraktRequest<TContentType> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType>(ITraktRequest<TContentType> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType>(ITraktRequest<TContentType> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        // post requests

        public Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPostRequest<TRequestBody> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        // put requests

        public Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPutRequest<TRequestBody> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        public Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request)
        {
            ValidateRequest(request);

            throw new NotImplementedException();
        }

        private void ValidateRequest(ITraktRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            request.Validate();
        }
    }
}
