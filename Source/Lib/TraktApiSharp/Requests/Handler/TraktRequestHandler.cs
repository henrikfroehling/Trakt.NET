namespace TraktApiSharp.Requests.Handler
{
    using Base;
    using Checkins.OAuth;
    using Core;
    using Exceptions;
    using Interfaces;
    using Interfaces.Base;
    using Objects.Basic;
    using Objects.JsonReader;
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
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using UriTemplates;
    using Utils;

    internal sealed class TraktRequestHandler : ITraktRequestHandler
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
        private const string MEDIA_TYPE = "application/json";
        private const string AUTHENTICATION_SCHEME = "Bearer";

        // Don't mark this field as readonly,
        // as it is manually set in unit tests
        internal static HttpClient s_httpClient;

        private readonly TraktClient _client;

        internal TraktRequestHandler(TraktClient client)
        {
            _client = client;
        }

        public Task<TraktNoContentResponse> ExecuteNoContentRequestAsync(ITraktRequest request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryNoContentAsync(SetupRequestMessage(request), cancellationToken);
        }

        public Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType>(ITraktRequest<TResponseContentType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QuerySingleItemAsync<TResponseContentType>(SetupRequestMessage(request), false, cancellationToken);
        }

        public Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType>(ITraktRequest<TResponseContentType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryListAsync<TResponseContentType>(SetupRequestMessage(request), cancellationToken);
        }

        public Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType>(ITraktRequest<TResponseContentType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryPagedListAsync<TResponseContentType>(SetupRequestMessage(request), cancellationToken);
        }

        // post requests

        public Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TResponseContentType>(ITraktPostRequest<TResponseContentType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryNoContentAsync(SetupRequestMessage(request), cancellationToken);
        }

        public Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            var isCheckinRequest = request is TraktCheckinRequest<TResponseContentType, TRequestBodyType>;
            return QuerySingleItemAsync<TResponseContentType>(SetupRequestMessage(request), isCheckinRequest, cancellationToken);
        }

        public Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryListAsync<TResponseContentType>(SetupRequestMessage(request), cancellationToken);
        }

        public Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPostRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryPagedListAsync<TResponseContentType>(SetupRequestMessage(request), cancellationToken);
        }

        // put requests

        public Task<TraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBodyType>(ITraktPutRequest<TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryNoContentAsync(SetupRequestMessage(request), cancellationToken);
        }

        public Task<TraktResponse<TResponseContentType>> ExecuteSingleItemRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QuerySingleItemAsync<TResponseContentType>(SetupRequestMessage(request), false, cancellationToken);
        }

        public Task<TraktListResponse<TResponseContentType>> ExecuteListRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryListAsync<TResponseContentType>(SetupRequestMessage(request), cancellationToken);
        }

        public Task<TraktPagedResponse<TResponseContentType>> ExecutePagedRequestAsync<TResponseContentType, TRequestBodyType>(ITraktPutRequest<TResponseContentType, TRequestBodyType> request, CancellationToken cancellationToken = default(CancellationToken))
        {
            PreExecuteRequest(request);
            return QueryPagedListAsync<TResponseContentType>(SetupRequestMessage(request), cancellationToken);
        }

        // query response helper methods

        private async Task<TraktNoContentResponse> QueryNoContentAsync(TraktHttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, false, cancellationToken).ConfigureAwait(false);
                Debug.Assert(responseMessage?.StatusCode == HttpStatusCode.NoContent, "precondition for generating no content response failed: invalid status code");

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

        private async Task<TraktResponse<TResponseContentType>> QuerySingleItemAsync<TResponseContentType>(TraktHttpRequestMessage requestMessage, bool isCheckinRequest = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, isCheckinRequest, cancellationToken).ConfigureAwait(false);
                Debug.Assert(responseMessage?.StatusCode != HttpStatusCode.NoContent, "precondition for generating single item response failed: invalid status code");

                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                Debug.Assert(responseContentStream != null, "precondition for deserializing response content failed: stream is null");

                ITraktObjectJsonReader<TResponseContentType> objectJsonReader = TraktJsonFactoryContainer.CreateObjectReader<TResponseContentType>();
                Debug.Assert(objectJsonReader != null, "precondition for deserializing response content failed: json content reader is null");

                TResponseContentType contentObject = await objectJsonReader.ReadObjectAsync(responseContentStream, cancellationToken).ConfigureAwait(false);
                bool hasValue = !EqualityComparer<TResponseContentType>.Default.Equals(contentObject, default(TResponseContentType));

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

        private async Task<TraktListResponse<TResponseContentType>> QueryListAsync<TResponseContentType>(TraktHttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, false, cancellationToken).ConfigureAwait(false);
                Debug.Assert(responseMessage?.StatusCode != HttpStatusCode.NoContent, "precondition for generating list response failed: invalid status code");

                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                Debug.Assert(responseContentStream != null, "precondition for deserializing response content failed: stream is null");

                ITraktArrayJsonReader<TResponseContentType> arrayJsonReader = TraktJsonFactoryContainer.CreateArrayReader<TResponseContentType>();
                Debug.Assert(arrayJsonReader != null, "precondition for deserializing response content failed: json content reader is null");

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

        private async Task<TraktPagedResponse<TResponseContentType>> QueryPagedListAsync<TResponseContentType>(TraktHttpRequestMessage requestMessage, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage responseMessage = null;

            try
            {
                responseMessage = await ExecuteRequestAsync(requestMessage, false, cancellationToken).ConfigureAwait(false);
                Debug.Assert(responseMessage?.StatusCode != HttpStatusCode.NoContent, "precondition for generating paged list response failed: invalid status code");

                Stream responseContentStream = await GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                Debug.Assert(responseContentStream != null, "precondition for deserializing response content failed: stream is null");

                ITraktArrayJsonReader<TResponseContentType> arrayJsonReader = TraktJsonFactoryContainer.CreateArrayReader<TResponseContentType>();
                Debug.Assert(arrayJsonReader != null, "precondition for deserializing response content failed: json content reader is null");

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

        private async Task<HttpResponseMessage> ExecuteRequestAsync(TraktHttpRequestMessage requestMessage, bool isCheckinRequest = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            HttpResponseMessage responseMessage = await s_httpClient.SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

            if (!responseMessage.IsSuccessStatusCode)
                await ErrorHandlingAsync(responseMessage, requestMessage, isCheckinRequest, cancellationToken).ConfigureAwait(false);

            return responseMessage;
        }

        private Task<Stream> GetResponseContentStreamAsync(HttpResponseMessage response)
            => response.Content != null ? response.Content.ReadAsStreamAsync() : Task.FromResult(default(Stream));

        private void PreExecuteRequest(ITraktRequest request)
        {
            ValidateRequest(request);
            SetupHttpClient();
        }

        private void ValidateRequest(ITraktRequest request)
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

        private string BuildUrl(ITraktRequest request)
        {
            var uriTemplate = new UriTemplate(request.UriTemplate);
            IDictionary<string, object> requestUriParameters = request.GetUriPathParameters();

            foreach (KeyValuePair<string, object> parameter in requestUriParameters)
                uriTemplate.AddParameterFromKeyValuePair(parameter.Key, parameter.Value);

            string uri = uriTemplate.Resolve();
            return $"{_client.Configuration.BaseUrl}{uri}";
        }

        private TraktHttpRequestMessage SetupRequestMessage(ITraktRequest request)
        {
            TraktHttpRequestMessage requestMessage = CreateRequestMessage(request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private TraktHttpRequestMessage SetupRequestMessage<TRequestBodyType>(ITraktPostRequest<TRequestBodyType> request)
        {
            TraktHttpRequestMessage requestMessage = CreateRequestMessage(request);
            AddRequestBodyContent(requestMessage, request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private TraktHttpRequestMessage SetupRequestMessage<TResponseContentType, TRequestBodyType>(ITraktPostRequest<TResponseContentType, TRequestBodyType> request)
        {
            TraktHttpRequestMessage requestMessage = CreateRequestMessage(request);
            AddRequestBodyContent(requestMessage, request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private TraktHttpRequestMessage SetupRequestMessage<TRequestBodyType>(ITraktPutRequest<TRequestBodyType> request)
        {
            TraktHttpRequestMessage requestMessage = CreateRequestMessage(request);
            AddRequestBodyContent(requestMessage, request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private TraktHttpRequestMessage SetupRequestMessage<TResponseContentType, TRequestBodyType>(ITraktPutRequest<TResponseContentType, TRequestBodyType> request)
        {
            TraktHttpRequestMessage requestMessage = CreateRequestMessage(request);
            AddRequestBodyContent(requestMessage, request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private TraktHttpRequestMessage CreateRequestMessage(ITraktRequest request)
        {
            const string seasonKey = "season";
            const string episodeKey = "episode";

            string url = BuildUrl(request);
            var requestMessage = new TraktHttpRequestMessage(request.Method, url) { Url = url };

            if (request is ITraktHasId)
            {
                var idRequest = request as ITraktHasId;

                requestMessage.ObjectId = idRequest?.Id;
                requestMessage.RequestObjectType = idRequest?.RequestObjectType;
            }

            IDictionary<string, object> parameters = request.GetUriPathParameters();

            if (parameters.Count != 0)
            {
                if (parameters.ContainsKey(seasonKey))
                {
                    var strSeasonNumber = (string)parameters[seasonKey];

                    if (uint.TryParse(strSeasonNumber, out uint seasonNumber))
                        requestMessage.SeasonNumber = seasonNumber;
                }

                if (parameters.ContainsKey(episodeKey))
                {
                    var strEpisodeNumber = (string)parameters[episodeKey];

                    if (uint.TryParse(strEpisodeNumber, out uint episodeNumber))
                        requestMessage.EpisodeNumber = episodeNumber;
                }
            }

            return requestMessage;
        }

        private void AddRequestBodyContent<TRequestBodyType>(TraktHttpRequestMessage requestMessage, ITraktHasRequestBody<TRequestBodyType> request)
        {
            if (requestMessage == null)
                throw new ArgumentNullException(nameof(requestMessage));

            requestMessage.Content = GetRequestBodyContent(request, out string requestBodyJson);
            requestMessage.RequestBodyJson = requestBodyJson;
        }

        private HttpContent GetRequestBodyContent<TRequestBodyType>(ITraktHasRequestBody<TRequestBodyType> request, out string requestBodyJson)
        {
            TRequestBodyType requestBody = request.RequestBody;
            bool requestBodyIsNull = EqualityComparer<TRequestBodyType>.Default.Equals(requestBody, default(TRequestBodyType));

            if (requestBodyIsNull)
            {
                requestBodyJson = string.Empty;
                return null;
            }

            string json = Json.Serialize(requestBody);
            requestBodyJson = json;
            return !string.IsNullOrEmpty(json) ? new StringContent(json, Encoding.UTF8, MEDIA_TYPE) : null;
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue(MEDIA_TYPE);

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIClientIdHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIClientIdHeaderKey, _client.ClientId);

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIVersionHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private void SetRequestMessageHeadersForAuthorization(TraktHttpRequestMessage requestMessage, TraktAuthorizationRequirement authorizationRequirement)
        {
            if (requestMessage == null)
                throw new ArgumentNullException(nameof(requestMessage));

            if (authorizationRequirement == TraktAuthorizationRequirement.Required)
            {
                if (!_client.Authentication.IsAuthorized)
                    throw new TraktAuthorizationException("authorization is required for this request, but the current authorization parameters are invalid");

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_SCHEME, _client.Authentication.Authorization.AccessToken);
            }

            if (authorizationRequirement == TraktAuthorizationRequirement.Optional && _client.Configuration.ForceAuthorization && _client.Authentication.IsAuthorized)
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_SCHEME, _client.Authentication.Authorization.AccessToken);
        }

        private void ParseResponseHeaderValues(ITraktResponseHeaders headerResults, HttpResponseHeaders responseHeaders)
        {
            if (responseHeaders.TryGetValues(HEADER_PAGINATION_PAGE_KEY, out IEnumerable<string> values))
            {
                string strPage = values.First();

                if (int.TryParse(strPage, out int page))
                    headerResults.Page = page;
            }

            if (responseHeaders.TryGetValues(HEADER_PAGINATION_LIMIT_KEY, out values))
            {
                string strLimit = values.First();

                if (int.TryParse(strLimit, out int limit))
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

        private async Task ErrorHandlingAsync(HttpResponseMessage response, TraktHttpRequestMessage requestMessage, bool isCheckinRequest = false, CancellationToken cancellationToken = default(CancellationToken))
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

        private static void HandleNotFoundStatusCode(TraktHttpRequestMessage requestMessage, string responseContent, string url, string requestBodyJson, string reasonPhrase)
        {
            TraktRequestObjectType? requestObjectType = requestMessage.RequestObjectType;

            if (requestObjectType.HasValue)
            {
                string objectId = requestMessage.ObjectId;
                uint seasonNr = requestMessage.SeasonNumber ?? 0;
                uint episodeNr = requestMessage.EpisodeNumber ?? 0;

                switch (requestObjectType.Value)
                {
                    case TraktRequestObjectType.Episodes:
                        throw new TraktEpisodeNotFoundException(objectId, seasonNr, episodeNr)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case TraktRequestObjectType.Seasons:
                        throw new TraktSeasonNotFoundException(objectId, seasonNr)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case TraktRequestObjectType.Shows:
                        throw new TraktShowNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case TraktRequestObjectType.Movies:
                        throw new TraktMovieNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case TraktRequestObjectType.People:
                        throw new TraktPersonNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case TraktRequestObjectType.Comments:
                        throw new TraktCommentNotFoundException(objectId)
                        {
                            RequestUrl = url,
                            RequestBody = requestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = reasonPhrase
                        };
                    case TraktRequestObjectType.Lists:
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

        private static async Task HandleConflictStatusCode(bool isCheckinRequest, string responseContent, string url, string requestBodyJson, string reasonPhrase, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (isCheckinRequest)
            {
                ITraktCheckinPostErrorResponse errorResponse = null;

                if (!string.IsNullOrEmpty(responseContent))
                {
                    ITraktObjectJsonReader<ITraktCheckinPostErrorResponse> errorResponseReader = TraktJsonFactoryContainer.CreateObjectReader<ITraktCheckinPostErrorResponse>();
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

        private static async Task HandleUnknownError(string responseContent, HttpStatusCode code, string url, string requestBodyJson, string reasonPhrase, CancellationToken cancellationToken = default(CancellationToken))
        {
            ITraktError error = null;

            try
            {
                ITraktObjectJsonReader<ITraktError> errorReader = TraktJsonFactoryContainer.CreateObjectReader<ITraktError>();
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
