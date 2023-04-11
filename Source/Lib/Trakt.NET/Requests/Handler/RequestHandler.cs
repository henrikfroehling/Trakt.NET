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
        private readonly ILogWriter _logWriter;

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
            _logWriter = client.LogWriter;
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
            return await QuerySingleItemAsync<TResponseContentType>(requestMessage, false, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
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
            return await QuerySingleItemAsync<TResponseContentType>(requestMessage, isCheckinRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
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
            return await QuerySingleItemAsync<TResponseContentType>(requestMessage, false, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
            ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
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

        private async Task<TraktResponse<TResponseContentType>> QuerySingleItemAsync<TResponseContentType>(ExtendedHttpRequestMessage requestMessage, bool isCheckinRequest = false, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, isCheckinRequest, cancellationToken);
                DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);
                DebugAsserter.AssertHttpResponseCodeIsNotExpected(responseMessage.StatusCode, HttpStatusCode.NoContent, DebugAsserter.SINGLE_ITEM_RESPONSE_PRECONDITION_INVALID_STATUS_CODE);
                Stream responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage);
                DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);

                _logWriter?.WriteLine($"QuerySingleItemAsync: Current Thread ID = {Thread.CurrentThread.ManagedThreadId}; Current Task ID = {Task.CurrentId}");
                _logWriter?.WriteLine($"QuerySingleItemAsync: Thread ID = {Thread.CurrentThread.ManagedThreadId}; Task ID = {Task.CurrentId}; URL = \"{requestMessage.Url}\"");

                IObjectJsonReader<TResponseContentType> objectJsonReader = JsonFactoryContainer.CreateObjectReader<TResponseContentType>();
                DebugAsserter.AssertObjectJsonReaderIsNotNull(objectJsonReader);
                TResponseContentType contentObject = await objectJsonReader.ReadObjectAsync(responseContentStream, cancellationToken);

                bool hasValue = !EqualityComparer<TResponseContentType>.Default.Equals(contentObject, default);
                _logWriter?.WriteLine($"QuerySingleItemAsync: Thread ID = {Thread.CurrentThread.ManagedThreadId}; Task ID = {Task.CurrentId}; HasValue = {hasValue}");

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
                _logWriter?.WriteLine($"QuerySingleItemAsync: Thread ID = {Thread.CurrentThread.ManagedThreadId}; Task ID = {Task.CurrentId}; Exception: {ex}");

                if (_throwsResponseExceptions)
                    throw;

                return new TraktResponse<TResponseContentType> { IsSuccess = false, Exception = ex };
            }
            finally
            {
                responseMessage?.Dispose();
            }
        }

        private async Task<TraktListResponse<TResponseContentType>> QueryListAsync<TResponseContentType>(ExtendedHttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, false, cancellationToken).ConfigureAwait(false);
                DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);
                DebugAsserter.AssertHttpResponseCodeIsNotExpected(responseMessage.StatusCode, HttpStatusCode.NoContent, DebugAsserter.LIST_RESPONSE_PRECONDITION_INVALID_STATUS_CODE);
                Stream responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);

                var response = new TraktListResponse<TResponseContentType>();

                if (typeof(TResponseContentType) == typeof(int))
                {
                    IArrayJsonReader<int> intArrayJsonReader = new IntArrayJsonReader();
                    IEnumerable<int> values = await intArrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                    response.IsSuccess = true;
                    response.HasValue = values != null;
                    response.Value = (IEnumerable<TResponseContentType>)values;
                }
                else
                {
                    IArrayJsonReader<TResponseContentType> arrayJsonReader = new ArrayJsonReader<TResponseContentType>();
                    DebugAsserter.AssertArrayJsonReaderIsNotNull(arrayJsonReader);
                    IEnumerable<TResponseContentType> contentObject = await arrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                    response.IsSuccess = true;
                    response.HasValue = contentObject != null;
                    response.Value = contentObject;
                }

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
                Stream responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);

                var response = new TraktPagedResponse<TResponseContentType>();

                if (typeof(TResponseContentType) == typeof(int))
                {
                    IArrayJsonReader<int> intArrayJsonReader = new IntArrayJsonReader();
                    IEnumerable<int> values = await intArrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);
                    
                    response.IsSuccess = true;
                    response.HasValue = values != null;
                    response.Value = (IEnumerable<TResponseContentType>)values;
                }
                else
                {
                    IArrayJsonReader<TResponseContentType> arrayJsonReader = new ArrayJsonReader<TResponseContentType>();
                    DebugAsserter.AssertArrayJsonReaderIsNotNull(arrayJsonReader);
                    IEnumerable<TResponseContentType> contentObject = await arrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                    response.IsSuccess = true;
                    response.HasValue = contentObject != null;
                    response.Value = contentObject;
                }

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
    }
}
