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
        private readonly TraktClient _client;
        private readonly RequestMessageBuilder _requestMessageBuilder;
        private static IRequestHandler s_requestHandler;

        internal RequestHandler(TraktClient client)
        {
            _client = client;
            _requestMessageBuilder = new RequestMessageBuilder(_client);
        }

        internal static IRequestHandler GetInstance(TraktClient client)
            => s_requestHandler ?? (s_requestHandler = new RequestHandler(client));

        public async Task<TraktNoContentResponse> ExecuteNoContentRequestAsync(IRequest request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).Build(cancellationToken).ConfigureAwait(false);
            return await QueryNoContentAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).Build(cancellationToken).ConfigureAwait(false);
            return await QuerySingleItemAsync<TResponseContentType>(requestMessage, false, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).Build(cancellationToken).ConfigureAwait(false);
            return await QueryPagedListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        internal static async Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType>(TraktClient client, IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            var requestHandler = new RequestHandler(client);
            var response = await requestHandler.ExecutePagedRequestAsync(request, cancellationToken).ConfigureAwait(false);
            response.SetRequestAndClient(request, client);
            return response;
        }

        // post requests

        public async Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(IPostRequest<TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build(cancellationToken).ConfigureAwait(false);
            return await QueryNoContentAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build(cancellationToken).ConfigureAwait(false);
            var isCheckinRequest = request is CheckinRequest<TResponseContentType, TRequestBodyType>;
            return await QuerySingleItemAsync<TResponseContentType>(requestMessage, isCheckinRequest, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build(cancellationToken).ConfigureAwait(false);
            return await QueryPagedListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        // put requests

        public async Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(IPutRequest<TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build(cancellationToken).ConfigureAwait(false);
            return await QueryNoContentAsync(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build(cancellationToken).ConfigureAwait(false);
            return await QuerySingleItemAsync<TResponseContentType>(requestMessage, false, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build(cancellationToken).ConfigureAwait(false);
            return await QueryListAsync<TResponseContentType>(requestMessage, cancellationToken).ConfigureAwait(false);
        }

        public async Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            ValidateRequest(request);
            ExtendedHttpRequestMessage requestMessage = await _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build(cancellationToken).ConfigureAwait(false);
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
                if (_client.Configuration.ThrowResponseExceptions)
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
                responseMessage = await ExecuteRequestAsync(requestMessage, isCheckinRequest, cancellationToken).ConfigureAwait(false);
                DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);
                DebugAsserter.AssertHttpResponseCodeIsNotExpected(responseMessage.StatusCode, HttpStatusCode.NoContent, DebugAsserter.SINGLE_ITEM_RESPONSE_PRECONDITION_INVALID_STATUS_CODE);
                Stream responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);
                IObjectJsonReader<TResponseContentType> objectJsonReader = JsonFactoryContainer.CreateObjectReader<TResponseContentType>();
                DebugAsserter.AssertObjectJsonReaderIsNotNull(objectJsonReader);
                TResponseContentType contentObject = await objectJsonReader.ReadObjectAsync(responseContentStream, cancellationToken).ConfigureAwait(false);
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
                if (_client.Configuration.ThrowResponseExceptions)
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
                    IList<int> values = await intArrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                    response.IsSuccess = true;
                    response.HasValue = values != null;
                    response.Value = (IList<TResponseContentType>)values;
                }
                else
                {
                    IArrayJsonReader<TResponseContentType> arrayJsonReader = new ArrayJsonReader<TResponseContentType>();
                    DebugAsserter.AssertArrayJsonReaderIsNotNull(arrayJsonReader);
                    IList<TResponseContentType> contentObjects = await arrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                    response.IsSuccess = true;
                    response.HasValue = contentObjects != null;
                    response.Value = contentObjects;
                }

                if (responseMessage.Headers != null)
                    ResponseHeaderParser.ParseResponseHeaderValues(response, responseMessage.Headers);

                return response;
            }
            catch (Exception ex)
            {
                if (_client.Configuration.ThrowResponseExceptions)
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
                    IList<int> values = await intArrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);
                    
                    response.IsSuccess = true;
                    response.HasValue = values != null;
                    response.Value = (IList<TResponseContentType>)values;
                }
                else
                {
                    IArrayJsonReader<TResponseContentType> arrayJsonReader = new ArrayJsonReader<TResponseContentType>();
                    DebugAsserter.AssertArrayJsonReaderIsNotNull(arrayJsonReader);
                    IList<TResponseContentType> contentObjects = await arrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                    response.IsSuccess = true;
                    response.HasValue = contentObjects != null;
                    response.Value = contentObjects;
                }

                if (responseMessage.Headers != null)
                    ResponseHeaderParser.ParsePagedResponseHeaderValues(response, responseMessage.Headers);

                return response;
            }
            catch (Exception ex)
            {
                if (_client.Configuration.ThrowResponseExceptions)
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
            HttpResponseMessage responseMessage = await _client.HttpClientProvider.GetHttpClient().SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

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
    }
}
