namespace TraktNet.Requests.Handler
{
    using Checkins.OAuth;
    using Core;
    using Interfaces;
    using Interfaces.Base;
    using Objects.Json;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class RequestHandler : IRequestHandler
    {
        private readonly bool _throwsResponseExceptions;
        private readonly IHttpClientProvider _httpClientProvider;
        private readonly string _clientId;
        private readonly int _apiVersion;
        private readonly string _baseUrl;
        private readonly string _accessToken;
        private readonly bool _isAuthorized;
        private readonly bool _forceAuthorization;

        internal RequestHandler(TraktClient client)
        {
            _throwsResponseExceptions = client.Configuration.ThrowResponseExceptions;
            _httpClientProvider = client.HttpClientProvider;
            _clientId = client.ClientId;
            _apiVersion = client.Configuration.ApiVersion;
            _baseUrl = client.Configuration.BaseUrl;
            _accessToken = client.Authentication.Authorization.AccessToken;
            _isAuthorized = client.Authentication.IsAuthorized;
            _forceAuthorization = client.Configuration.ForceAuthorization;
        }

        public async Task<TraktNoContentResponse> ExecuteNoContentRequestAsync(IRequest request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryNoContentAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QuerySingleItemAsync<TResponseContentType>(false, requestMessage, false, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemStreamRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QuerySingleItemAsync<TResponseContentType>(true, requestMessage, false, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(false, requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListStreamRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(true, requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryPagedListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        // post requests

        public async Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(IPostRequest<TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryNoContentAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            var isCheckinRequest = request is CheckinRequest<TResponseContentType, TRequestBodyType>;
            return await QuerySingleItemAsync<TResponseContentType>(false, requestMessage, isCheckinRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(false, requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryPagedListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        // put requests

        public async Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(IPutRequest<TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryNoContentAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QuerySingleItemAsync<TResponseContentType>(false, requestMessage, false, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(false, requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryPagedListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        // query response helper methods

        private async Task<TraktNoContentResponse> QueryNoContentAsync(ExtendedHttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, false, cancellationToken).ConfigureAwait(false);
                DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);
                DebugAsserter.AssertHttpResponseCodeIsExpected(responseMessage.StatusCode, HttpStatusCode.NoContent, DebugAsserter.NO_CONTENT_RESPONSE_PRECONDITION_INVALID_STATUS_CODE);
                return new TraktNoContentResponse { IsSuccess = true };
            }
            catch (Exception ex)
            {
                if (_throwsResponseExceptions)
                    throw;

                return new TraktNoContentResponse { IsSuccess = false, Exception = ex };
            }
            finally
            {
                responseMessage?.Dispose();
            }
        }

        private async Task<TraktResponse<TResponseContentType>> QuerySingleItemAsync<TResponseContentType>(bool asyncStream, ExtendedHttpRequestMessage requestMessage, bool isCheckinRequest = false, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, isCheckinRequest, cancellationToken).ConfigureAwait(false);
                DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);
                DebugAsserter.AssertHttpResponseCodeIsNotExpected(responseMessage.StatusCode, HttpStatusCode.NoContent, DebugAsserter.SINGLE_ITEM_RESPONSE_PRECONDITION_INVALID_STATUS_CODE);
                TResponseContentType contentObject = await ReadContentObjectAsync<TResponseContentType>(asyncStream, responseMessage, cancellationToken).ConfigureAwait(false);
                bool hasValue = !EqualityComparer<TResponseContentType>.Default.Equals(contentObject, default);

                var response = new TraktResponse<TResponseContentType>
                {
                    IsSuccess = true,
                    HasValue = hasValue,
                    Value = contentObject
                };

                if (responseMessage.Headers != null)
                    ResponseHeaderParser.ParseResponseHeaderValues(response, responseMessage.Headers);

                return response;
            }
            catch (Exception ex)
            {
                if (_throwsResponseExceptions)
                    throw;

                return new TraktResponse<TResponseContentType> { IsSuccess = false, Exception = ex };
            }
            finally
            {
                responseMessage?.Dispose();
            }
        }

        private async Task<TraktListResponse<TResponseContentType>> QueryListAsync<TResponseContentType>(bool asyncStream, ExtendedHttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, false, cancellationToken).ConfigureAwait(false);
                DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);
                DebugAsserter.AssertHttpResponseCodeIsNotExpected(responseMessage.StatusCode, HttpStatusCode.NoContent, DebugAsserter.LIST_RESPONSE_PRECONDITION_INVALID_STATUS_CODE);
                IEnumerable<TResponseContentType> contentObjects = await ReadContentListAsync<TResponseContentType>(asyncStream, responseMessage, cancellationToken).ConfigureAwait(false);

                var response = new TraktListResponse<TResponseContentType>
                {
                    IsSuccess = true,
                    HasValue = contentObjects != null,
                    Value = (IEnumerable<TResponseContentType>)contentObjects
                };

                if (responseMessage.Headers != null)
                    ResponseHeaderParser.ParseResponseHeaderValues(response, responseMessage.Headers);

                return response;
            }
            catch (Exception ex)
            {
                if (_throwsResponseExceptions)
                    throw;

                return new TraktListResponse<TResponseContentType> { IsSuccess = false, Exception = ex };
            }
            finally
            {
                responseMessage?.Dispose();
            }
        }

        private async Task<TraktPagedResponse<TResponseContentType>> QueryPagedListAsync<TResponseContentType>(ExtendedHttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, false, cancellationToken).ConfigureAwait(false);
                DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);
                DebugAsserter.AssertHttpResponseCodeIsNotExpected(responseMessage.StatusCode, HttpStatusCode.NoContent, DebugAsserter.PAGED_LIST_RESPONSE_PRECONDITION_INVALID_STATUS_CODE);
                IEnumerable<TResponseContentType> contentObjects = await ReadContentListAsync<TResponseContentType>(false, responseMessage, cancellationToken).ConfigureAwait(false);

                var response = new TraktPagedResponse<TResponseContentType>
                {
                    IsSuccess = true,
                    HasValue = contentObjects != null,
                    Value = (IEnumerable<TResponseContentType>)contentObjects
                };

                if (responseMessage.Headers != null)
                    ResponseHeaderParser.ParsePagedResponseHeaderValues(response, responseMessage.Headers);

                return response;
            }
            catch (Exception ex)
            {
                if (_throwsResponseExceptions)
                    throw;

                return new TraktPagedResponse<TResponseContentType> { IsSuccess = false, Exception = ex };
            }
            finally
            {
                responseMessage?.Dispose();
            }
        }

        private async Task<HttpResponseMessage> ExecuteRequestAsync(ExtendedHttpRequestMessage requestMessage, bool isCheckinRequest = false, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage = await _httpClientProvider.GetHttpClient(_clientId).SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
                await ResponseErrorHandler.HandleErrorsAsync(requestMessage, responseMessage, isCheckinRequest, cancellationToken: cancellationToken).ConfigureAwait(false);

            return responseMessage;
        }

        private void ValidateRequest(IRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            request.Validate();
        }

        private RequestMessageBuilder CreateRequestMessageBuilder(IRequest request = null, IRequestBody requestBody = null)
            => new RequestMessageBuilder(_clientId, _apiVersion, _baseUrl, _accessToken, _isAuthorized, _forceAuthorization)
               {
                    Request = request,
                    RequestBody = requestBody
               };

        private IArrayJsonReader<TResponseContentType> CreateArrayReader<TResponseContentType>()
        {
            if (typeof(TResponseContentType) == typeof(int))
                return (IArrayJsonReader<TResponseContentType>)new IntArrayJsonReader();

            return new ArrayJsonReader<TResponseContentType>();
        }

        private async Task<TResponseContentType> ReadContentObjectAsync<TResponseContentType>(bool asyncStream, HttpResponseMessage responseMessage, CancellationToken cancellationToken = default)
        {
            DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);

            if (asyncStream)
            {
                IObjectJsonReader<TResponseContentType> asyncObjectJsonReader = JsonFactoryContainer.CreateObjectReader<TResponseContentType>();
                DebugAsserter.AssertObjectJsonReaderIsNotNull(asyncObjectJsonReader);

                string responseContent = await ResponseMessageHelper.GetResponseContentAsync(responseMessage).ConfigureAwait(false);
                DebugAsserter.AssertResponseContentIsNotEmpty(responseContent);
                return await asyncObjectJsonReader.ReadObjectAsync(responseContent, cancellationToken).ConfigureAwait(false);
            }

            IObjectJsonReader<TResponseContentType> objectJsonReader = JsonFactoryContainer.CreateObjectReader<TResponseContentType>();
            DebugAsserter.AssertObjectJsonReaderIsNotNull(objectJsonReader);

            Stream responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
            DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);
            return await objectJsonReader.ReadObjectAsync(responseContentStream, cancellationToken).ConfigureAwait(false);
        }

        private async Task<IEnumerable<TResponseContentType>> ReadContentListAsync<TResponseContentType>(bool asyncStream, HttpResponseMessage responseMessage, CancellationToken cancellationToken = default)
        {
            DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);

            if (asyncStream)
            {
                IArrayJsonReader<TResponseContentType> asyncArrayJsonReader = CreateArrayReader<TResponseContentType>();
                DebugAsserter.AssertArrayJsonReaderIsNotNull(asyncArrayJsonReader);

                string responseContent = await ResponseMessageHelper.GetResponseContentAsync(responseMessage).ConfigureAwait(false);
                DebugAsserter.AssertResponseContentIsNotEmpty(responseContent);
                return await asyncArrayJsonReader.ReadArrayAsync(responseContent, cancellationToken).ConfigureAwait(false);
            }

            IArrayJsonReader<TResponseContentType> arrayJsonReader = CreateArrayReader<TResponseContentType>();
            DebugAsserter.AssertArrayJsonReaderIsNotNull(arrayJsonReader);

            Stream responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
            DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);
            return await arrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);
        }
    }
}
