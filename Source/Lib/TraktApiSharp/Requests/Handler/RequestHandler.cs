namespace TraktApiSharp.Requests.Handler
{
    using Base;
    using Checkins.OAuth;
    using Core;
    using Exceptions;
    using Interfaces;
    using Interfaces.Base;
    using Objects.Basic;
    using Objects.Json;
    using Objects.Post.Checkins.Responses;
    using Responses;
    using Responses.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class RequestHandler : IRequestHandler
    {
        private const string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
        private const string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
        private const string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
        private const string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";
        private const string HEADER_TRENDING_USER_COUNT_KEY = "X-Trending-User-Count";
        private const string HEADER_SORT_BY_KEY = "X-Sort-By";
        private const string HEADER_SORT_HOW_KEY = "X-Sort-How";
        private const string HEADER_STARTDATE_KEY = "X-Start-Date";
        private const string HEADER_ENDDATE_KEY = "X-End-Date";
        private const string HEADER_PRIVATE_USER_KEY = "X-Private-User";
        private const string HEADER_X_ITEM_ID = "X-Item-ID";
        private const string HEADER_X_ITEM_TYPE = "X-Item-Type";
        private const string MEDIA_TYPE = "application/json";

        // Don't mark this field as readonly,
        // as it is manually set in unit tests
        internal static HttpClient s_httpClient;

        private readonly TraktClient _client;
        private readonly RequestMessageBuilder _requestMessageBuilder;

        internal RequestHandler(TraktClient client)
        {
            _client = client;
            _requestMessageBuilder = new RequestMessageBuilder(_client);
        }

        public Task<TraktNoContentResponse> ExecuteNoContentRequestAsync(IRequest request, CancellationToken cancellationToken = default)
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).Build();
            return QueryNoContentAsync(requestMessage, cancellationToken);
        }

        public Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).Build();
            return QuerySingleItemAsync<TResponseContentType>(requestMessage, false, cancellationToken);
        }

        public Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).Build();
            return QueryListAsync<TResponseContentType>(requestMessage, cancellationToken);
        }

        public Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType>(IRequest<TResponseContentType> request, CancellationToken cancellationToken = default)
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).Build();
            return QueryPagedListAsync<TResponseContentType>(requestMessage, cancellationToken);
        }

        // post requests

        public Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(IPostRequest<TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build();
            return QueryNoContentAsync(requestMessage, cancellationToken);
        }

        public Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build();
            var isCheckinRequest = request is CheckinRequest<TResponseContentType, TRequestBodyType>;
            return QuerySingleItemAsync<TResponseContentType>(requestMessage, isCheckinRequest, cancellationToken);
        }

        public Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build();
            return QueryListAsync<TResponseContentType>(requestMessage, cancellationToken);
        }

        public Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(IPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build();
            return QueryPagedListAsync<TResponseContentType>(requestMessage, cancellationToken);
        }

        // put requests

        public Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(IPutRequest<TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build();
            return QueryNoContentAsync(requestMessage, cancellationToken);
        }

        public Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build();
            return QuerySingleItemAsync<TResponseContentType>(requestMessage, false, cancellationToken);
        }

        public Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build();
            return QueryListAsync<TResponseContentType>(requestMessage, cancellationToken);
        }

        public Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(IPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            PreExecuteRequest(request);
            ExtendedHttpRequestMessage requestMessage = _requestMessageBuilder.Reset(request).WithRequestBody(request.RequestBody).Build();
            return QueryPagedListAsync<TResponseContentType>(requestMessage, cancellationToken);
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
                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
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
                    ParseResponseHeaderValues(response, responseMessage.Headers);

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
                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);
                IArrayJsonReader<TResponseContentType> arrayJsonReader = JsonFactoryContainer.CreateArrayReader<TResponseContentType>();
                DebugAsserter.AssertArrayJsonReaderIsNotNull(arrayJsonReader);
                IEnumerable<TResponseContentType> contentObject = await arrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                var response = new TraktListResponse<TResponseContentType>
                {
                    IsSuccess = true,
                    HasValue = contentObject != null,
                    Value = contentObject
                };

                if (responseMessage.Headers != null)
                    ParseResponseHeaderValues(response, responseMessage.Headers);

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
                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                DebugAsserter.AssertResponseContentStreamIsNotNull(responseContentStream);
                IArrayJsonReader<TResponseContentType> arrayJsonReader = JsonFactoryContainer.CreateArrayReader<TResponseContentType>();
                DebugAsserter.AssertArrayJsonReaderIsNotNull(arrayJsonReader);
                IEnumerable<TResponseContentType> contentObject = await arrayJsonReader.ReadArrayAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                var response = new TraktPagedResponse<TResponseContentType>
                {
                    IsSuccess = true,
                    HasValue = contentObject != null,
                    Value = contentObject
                };

                if (responseMessage.Headers != null)
                {
                    ParseResponseHeaderValues(response, responseMessage.Headers);
                    ParsePagedResponseHeaderValues(response, responseMessage.Headers);
                }

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
            HttpResponseMessage responseMessage = await s_httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
                await ErrorHandlingAsync(responseMessage, requestMessage, isCheckinRequest, cancellationToken).ConfigureAwait(false);

            return responseMessage;
        }

        private Task<Stream> GetResponseContentStreamAsync(HttpResponseMessage response)
            => response.Content != null ? response.Content.ReadAsStreamAsync() : Task.FromResult(default(Stream));

        private void PreExecuteRequest(IRequest request)
        {
            ValidateRequest(request);
            SetupHttpClient();
        }

        private void ValidateRequest(IRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            request.Validate();
        }

        private void SetupHttpClient()
        {
            if (s_httpClient == null)
                s_httpClient = new HttpClient();

            SetDefaultRequestHeaders(s_httpClient);
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue(MEDIA_TYPE);

            if (!httpClient.DefaultRequestHeaders.Contains(Constants.APIClientIdHeaderKey))
                httpClient.DefaultRequestHeaders.Add(Constants.APIClientIdHeaderKey, _client.ClientId);

            if (!httpClient.DefaultRequestHeaders.Contains(Constants.APIVersionHeaderKey))
                httpClient.DefaultRequestHeaders.Add(Constants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private void ParseResponseHeaderValues(ITraktResponseHeaders headerResults, HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders.TryGetValues(HEADER_PAGINATION_PAGE_KEY, out IEnumerable<string> values))
            {
                string strPage = values.First();

                if (uint.TryParse(strPage, out uint page))
                    headerResults.Page = page;
            }

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_LIMIT_KEY, out values))
            {
                string strLimit = values.First();

                if (uint.TryParse(strLimit, out uint limit))
                    headerResults.Limit = limit;
            }

            if (responseHeaders.TryGetValues(HEADER_TRENDING_USER_COUNT_KEY, out values))
            {
                string strTrendingUserCount = values.First();

                if (int.TryParse(strTrendingUserCount, out int userCount))
                    headerResults.TrendingUserCount = userCount;
            }

            if (responseHeaders.TryGetValues(HEADER_SORT_BY_KEY, out values))
                headerResults.SortBy = values.First();

            if (responseHeaders.TryGetValues(HEADER_SORT_HOW_KEY, out values))
                headerResults.SortHow = values.First();

            if (responseHeaders.TryGetValues(HEADER_PRIVATE_USER_KEY, out values))
            {
                string strIsPrivateUser = values.First();

                if (bool.TryParse(strIsPrivateUser, out bool isPrivateUser))
                    headerResults.IsPrivateUser = isPrivateUser;
            }

            if (responseHeaders.TryGetValues(HEADER_STARTDATE_KEY, out values))
            {
                string strStartDate = values.First();

                if (DateTime.TryParse(strStartDate, out DateTime startDate))
                    headerResults.StartDate = startDate.ToUniversalTime();
            }

            if (responseHeaders.TryGetValues(HEADER_ENDDATE_KEY, out values))
            {
                string strEndDate = values.First();

                if (DateTime.TryParse(strEndDate, out DateTime endDate))
                    headerResults.EndDate = endDate.ToUniversalTime();
            }

            if (responseHeaders.TryGetValues(HEADER_X_ITEM_ID, out values))
            {
                string strXItemId = values.First();

                if (int.TryParse(strXItemId, out int id))
                    headerResults.XItemId = id;
            }

            if (responseHeaders.TryGetValues(HEADER_X_ITEM_TYPE, out values))
                headerResults.XItemType = values.First();
        }

        private void ParsePagedResponseHeaderValues(ITraktPagedResponseHeaders headerResults, HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders.TryGetValues(HEADER_PAGINATION_PAGE_COUNT_KEY, out IEnumerable<string> values))
            {
                string strPageCount = values.First();

                if (int.TryParse(strPageCount, out int pageCount))
                    headerResults.PageCount = pageCount;
            }

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_ITEM_COUNT_KEY, out values))
            {
                string strItemCount = values.First();

                if (int.TryParse(strItemCount, out int itemCount))
                    headerResults.ItemCount = itemCount;
            }
        }

        private async Task ErrorHandlingAsync(HttpResponseMessage response, ExtendedHttpRequestMessage requestMessage, bool isCheckinRequest = false, CancellationToken cancellationToken = default)
        {
            var responseContent = string.Empty;

            if (response.Content != null)
                responseContent = await response.Content.ReadAsStringAsync();

            HttpStatusCode code = response.StatusCode;
            string url = requestMessage.Url;
            string requestBodyJson = requestMessage.RequestBodyJson;
            string reasonPhrase = response.ReasonPhrase;

            switch (code)
            {
                case HttpStatusCode.NotFound:
                    HandleNotFoundStatusCode(requestMessage, responseContent, url, requestBodyJson, reasonPhrase);
                    break;
                case HttpStatusCode.BadRequest:
                    throw new TraktBadRequestException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.Unauthorized:
                    throw new TraktAuthorizationException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.Forbidden:
                    throw new TraktForbiddenException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.MethodNotAllowed:
                    throw new TraktMethodNotFoundException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.Conflict:
                    await HandleConflictStatusCode(isCheckinRequest, responseContent, url, requestBodyJson, reasonPhrase, cancellationToken);
                    break;
                case HttpStatusCode.InternalServerError:
                    throw new TraktServerException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case HttpStatusCode.BadGateway:
                    throw new TraktBadGatewayException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)412:
                    throw new TraktPreconditionFailedException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)422:
                    throw new TraktValidationException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)429:
                    throw new TraktRateLimitException()
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)503:
                case (HttpStatusCode)504:
                    throw new TraktServerUnavailableException("Service Unavailable - server overloaded (try again in 30s)")
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        StatusCode = HttpStatusCode.ServiceUnavailable,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
                case (HttpStatusCode)520:
                case (HttpStatusCode)521:
                case (HttpStatusCode)522:
                    throw new TraktServerUnavailableException("Service Unavailable - Cloudflare error")
                    {
                        RequestUrl = url,
                        RequestBody = requestBodyJson,
                        StatusCode = HttpStatusCode.ServiceUnavailable,
                        Response = responseContent,
                        ServerReasonPhrase = reasonPhrase
                    };
            }

            await HandleUnknownError(responseContent, code, url, requestBodyJson, reasonPhrase, cancellationToken);
        }

        private static void HandleNotFoundStatusCode(ExtendedHttpRequestMessage requestMessage, string responseContent, string url, string requestBodyJson, string reasonPhrase)
        {
            RequestObjectType? requestObjectType = requestMessage.RequestObjectType;

            if (requestObjectType.HasValue)
            {
                string objectId = requestMessage.ObjectId;
                uint seasonNr = requestMessage.SeasonNumber ?? 0;
                uint episodeNr = requestMessage.EpisodeNumber ?? 0;

                switch (requestObjectType.Value)
                {
                    case RequestObjectType.Episodes:
                        throw new TraktEpisodeNotFoundException(objectId, seasonNr, episodeNr)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case RequestObjectType.Seasons:
                        throw new TraktSeasonNotFoundException(objectId, seasonNr)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case RequestObjectType.Shows:
                        throw new TraktShowNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case RequestObjectType.Movies:
                        throw new TraktMovieNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case RequestObjectType.People:
                        throw new TraktPersonNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case RequestObjectType.Comments:
                        throw new TraktCommentNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case RequestObjectType.Lists:
                        throw new TraktListNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    default:
                        throw new TraktObjectNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                }
            }

            throw new TraktNotFoundException($"Resource not found - Reason Phrase: {reasonPhrase}");
        }

        private static async Task HandleConflictStatusCode(bool isCheckinRequest, string responseContent, string url, string requestBodyJson, string reasonPhrase, CancellationToken cancellationToken = default)
        {
            if (isCheckinRequest)
            {
                ITraktCheckinPostErrorResponse errorResponse = null;

                if (!string.IsNullOrEmpty(responseContent))
                {
                    IObjectJsonReader<ITraktCheckinPostErrorResponse> errorResponseReader = JsonFactoryContainer.CreateObjectReader<ITraktCheckinPostErrorResponse>();
                    errorResponse = await errorResponseReader.ReadObjectAsync(responseContent, cancellationToken);
                }

                throw new TraktCheckinException("checkin is already in progress")
                {
                    RequestUrl = url,
                    RequestBody = requestBodyJson,
                    Response = responseContent,
                    ServerReasonPhrase = reasonPhrase,
                    ExpiresAt = errorResponse?.ExpiresAt
                };
            }

            throw new TraktConflictException()
            {
                RequestUrl = url,
                RequestBody = requestBodyJson,
                Response = responseContent,
                ServerReasonPhrase = reasonPhrase
            };
        }

        private static async Task HandleUnknownError(string responseContent, HttpStatusCode code, string url, string requestBodyJson, string reasonPhrase, CancellationToken cancellationToken = default)
        {
            ITraktError error = null;

            try
            {
                IObjectJsonReader<ITraktError> errorReader = JsonFactoryContainer.CreateObjectReader<ITraktError>();
                error = await errorReader.ReadObjectAsync(responseContent, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new TraktException("json convert exception", ex);
            }

            var errorMessage = (error == null || string.IsNullOrEmpty(error.Description))
                                    ? $"Trakt API error without content. Response status code was {(int)code}"
                                    : error.Description;

            throw new TraktException(errorMessage)
            {
                RequestUrl = url,
                RequestBody = requestBodyJson,
                Response = responseContent,
                ServerReasonPhrase = reasonPhrase
            };
        }
    }
}
