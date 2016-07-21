using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TraktApiSharp.Tests")]

namespace TraktApiSharp.Requests.Base
{
    using Core;
    using Exceptions;
    using Newtonsoft.Json;
    using Objects.Basic;
    using Objects.Post.Checkins.Responses;
    using Params;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using UriTemplates;

    internal abstract class TraktRequest<TResult, TItem, TRequestBody> : ITraktRequest<TResult, TItem>
    {
        private static string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
        private static string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
        private static string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
        private static string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";
        private static string HEADER_TRENDING_USER_COUNT_KEY = "X-Trending-User-Count";

        protected TraktRequest(TraktClient client)
        {
            Client = client;
            PaginationOptions = new TraktPaginationOptions();
        }

        public async Task<TResult> QueryAsync()
        {
            Validate();

            var httpClient = TraktConfiguration.HTTP_CLIENT;

            if (httpClient == null)
                httpClient = new HttpClient();

            SetDefaultRequestHeaders(httpClient);

            var request = new HttpRequestMessage(Method, Url) { Content = RequestBodyContent };
            SetRequestHeadersForAuthorization(request);

            var response = await httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
                ErrorHandling(response);

            var responseContent = response.Content != null ? await response.Content.ReadAsStringAsync() : string.Empty;

            // No content
            if (string.IsNullOrEmpty(responseContent) || response.StatusCode == HttpStatusCode.NoContent)
                return default(TResult);

            // Handle list result
            if (IsListResult)
                return await HandleListResult(response, responseContent);

            // Single object item
            return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseContent));
        }

        internal TraktClient Client { get; private set; }

        internal string Id { get; set; }

        internal virtual int Season { get; set; }

        internal virtual int Episode { get; set; }

        internal TraktExtendedOption ExtendedOption { get; set; }

        internal TraktCommonFilter Filter { get; set; }

        internal TraktPaginationOptions PaginationOptions { get; set; }

        internal bool AuthorizationHeaderRequired => AuthorizationRequirement == TraktAuthorizationRequirement.Required;

        internal TRequestBody RequestBody { get; set; }

        internal string Url => BuildUrl();

        protected abstract string UriTemplate { get; }

        protected virtual IDictionary<string, object> GetUriPathParameters()
        {
            return new Dictionary<string, object>();
        }

        private string BuildUrl()
        {
            var uriPath = new UriTemplate(UriTemplate);
            var pathParams = GetUriPathParameters();

            foreach (var param in pathParams)
                uriPath.AddParameterFromKeyValuePair(param.Key, param.Value);

            if (ExtendedOption != null && ExtendedOption.HasAnySet)
                uriPath.AddParameters(new { extended = ExtendedOption.Resolve() });

            if (Filter != null && Filter.HasValues)
                uriPath.AddParametersFromDictionary(Filter.GetParameters());

            if (SupportsPagination || SupportsPaginationParameters)
            {
                if (PaginationOptions.Page != null)
                    uriPath.AddParameterFromKeyValuePair("page", PaginationOptions.Page.ToString());

                if (PaginationOptions.Limit != null)
                    uriPath.AddParameterFromKeyValuePair("limit", PaginationOptions.Limit.ToString());
            }

            var uri = uriPath.Resolve();
            return $"{Client.Configuration.BaseUrl}{uri}";
        }

        protected abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        protected virtual TraktRequestObjectType? RequestObjectType => null;

        protected virtual bool IsListResult => false;

        protected virtual bool SupportsPagination => false;

        protected virtual bool SupportsPaginationParameters => false;

        protected virtual bool IsCheckinRequest => false;

        protected abstract HttpMethod Method { get; }

        protected HttpContent RequestBodyContent
        {
            get
            {
                var json = RequestBodyJson;
                return !string.IsNullOrEmpty(json) ? new StringContent(json, Encoding.UTF8, "application/json") : null;
            }
        }

        protected string RequestBodyJson
        {
            get
            {
                if (RequestBody == null)
                    return null;

                return JsonConvert.SerializeObject(RequestBody, new JsonSerializerSettings()
                {
                    Formatting = Formatting.None,
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        protected virtual void Validate() { }

        protected virtual void SetRequestHeadersForAuthorization(HttpRequestMessage request)
        {
            if (AuthorizationHeaderRequired)
            {
                if (!Client.Authentication.IsAuthorized)
                    throw new TraktAuthorizationException("authorization is required for this request, but the current authorization parameters are invalid");

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Client.Authentication.Authorization.AccessToken);
            }

            if (AuthorizationRequirement == TraktAuthorizationRequirement.Optional && Client.Configuration.ForceAuthorization && Client.Authentication.IsAuthorized)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Client.Authentication.Authorization.AccessToken);
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIClientIdHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIClientIdHeaderKey, Client.ClientId);

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIVersionHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIVersionHeaderKey, $"{Client.Configuration.ApiVersion}");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private async Task<TResult> HandleListResult(HttpResponseMessage response, string responseContent)
        {
            if (SupportsPagination)
            {
                if (typeof(TResult) != typeof(TraktPaginationListResult<TItem>))
                    throw new InvalidCastException($"{typeof(TResult).ToString()} cannot be converted to TraktPaginationListResult<{typeof(TItem).ToString()}>");

                var typePaginationElement = typeof(TResult).GenericTypeArguments[0];
                var typePaginationList = typeof(TraktPaginationListResult<>).MakeGenericType(typePaginationElement);
                var paginationListResult = Activator.CreateInstance(typePaginationList);

                (paginationListResult as TraktPaginationListResult<TItem>).Items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<TItem>>(responseContent));

                if (response.Headers != null)
                    ParseHeaderValues(paginationListResult as TraktPaginationListResult<TItem>, response.Headers);

                return (TResult)paginationListResult;
            }

            var results = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<TItem>>(responseContent));
            return (TResult)results;
        }

        private void ParseHeaderValues(TraktPaginationListResult<TItem> paginationListResult, HttpResponseHeaders headers)
        {
            IEnumerable<string> values;

            if (headers.TryGetValues(HEADER_PAGINATION_PAGE_KEY, out values))
            {
                var strPage = values.First();
                int page;

                if (int.TryParse(strPage, out page))
                    paginationListResult.Page = page;
            }

            if (headers.TryGetValues(HEADER_PAGINATION_LIMIT_KEY, out values))
            {
                var strLimit = values.First();
                int limit;

                if (int.TryParse(strLimit, out limit))
                    paginationListResult.Limit = limit;
            }

            if (headers.TryGetValues(HEADER_PAGINATION_PAGE_COUNT_KEY, out values))
            {
                var strPageCount = values.First();
                int pageCount;

                if (int.TryParse(strPageCount, out pageCount))
                    paginationListResult.PageCount = pageCount;
            }

            if (headers.TryGetValues(HEADER_PAGINATION_ITEM_COUNT_KEY, out values))
            {
                var strItemCount = values.First();
                int itemCount;

                if (int.TryParse(strItemCount, out itemCount))
                    paginationListResult.ItemCount = itemCount;
            }

            if (headers.TryGetValues(HEADER_TRENDING_USER_COUNT_KEY, out values))
            {
                var strUserCount = values.First();
                int userCount;

                if (int.TryParse(strUserCount, out userCount))
                    paginationListResult.UserCount = userCount;
            }
        }

        private void ErrorHandling(HttpResponseMessage response)
        {
            var responseContent = string.Empty;

            if (response.Content != null)
                responseContent = response.Content.ReadAsStringAsync().Result;

            var code = response.StatusCode;

            switch (code)
            {
                case HttpStatusCode.NotFound:
                    {
                        if (RequestObjectType.HasValue)
                        {
                            switch (RequestObjectType.Value)
                            {
                                case TraktRequestObjectType.Episodes:
                                    throw new TraktEpisodeNotFoundException(Id, Season, Episode)
                                    {
                                        RequestUrl = Url,
                                        RequestBody = RequestBodyJson,
                                        Response = responseContent,
                                        ServerReasonPhrase = response.ReasonPhrase
                                    };
                                case TraktRequestObjectType.Seasons:
                                    throw new TraktSeasonNotFoundException(Id, Season)
                                    {
                                        RequestUrl = Url,
                                        RequestBody = RequestBodyJson,
                                        Response = responseContent,
                                        ServerReasonPhrase = response.ReasonPhrase
                                    };
                                case TraktRequestObjectType.Shows:
                                    throw new TraktShowNotFoundException(Id)
                                    {
                                        RequestUrl = Url,
                                        RequestBody = RequestBodyJson,
                                        Response = responseContent,
                                        ServerReasonPhrase = response.ReasonPhrase
                                    };
                                case TraktRequestObjectType.Movies:
                                    throw new TraktMovieNotFoundException(Id)
                                    {
                                        RequestUrl = Url,
                                        RequestBody = RequestBodyJson,
                                        Response = responseContent,
                                        ServerReasonPhrase = response.ReasonPhrase
                                    };
                                case TraktRequestObjectType.People:
                                    throw new TraktPersonNotFoundException(Id)
                                    {
                                        RequestUrl = Url,
                                        RequestBody = RequestBodyJson,
                                        Response = responseContent,
                                        ServerReasonPhrase = response.ReasonPhrase
                                    };
                                case TraktRequestObjectType.Comments:
                                    throw new TraktCommentNotFoundException(Id)
                                    {
                                        RequestUrl = Url,
                                        RequestBody = RequestBodyJson,
                                        Response = responseContent,
                                        ServerReasonPhrase = response.ReasonPhrase
                                    };
                                case TraktRequestObjectType.Lists:
                                    throw new TraktListNotFoundException(Id)
                                    {
                                        RequestUrl = Url,
                                        RequestBody = RequestBodyJson,
                                        Response = responseContent,
                                        ServerReasonPhrase = response.ReasonPhrase
                                    };
                                case TraktRequestObjectType.Unspecified:
                                default:
                                    throw new TraktObjectNotFoundException(Id)
                                    {
                                        RequestUrl = Url,
                                        RequestBody = RequestBodyJson,
                                        Response = responseContent,
                                        ServerReasonPhrase = response.ReasonPhrase
                                    };
                            }
                        }

                        throw new TraktNotFoundException($"Resource not found - Reason Phrase: {response.ReasonPhrase}");
                    }
                case HttpStatusCode.BadRequest:
                    throw new TraktBadRequestException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case HttpStatusCode.Unauthorized:
                    throw new TraktAuthorizationException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case HttpStatusCode.Forbidden:
                    throw new TraktForbiddenException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case HttpStatusCode.MethodNotAllowed:
                    throw new TraktMethodNotFoundException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case HttpStatusCode.Conflict:
                    if (IsCheckinRequest)
                    {
                        TraktCheckinPostErrorResponse errorResponse = null;

                        if (!string.IsNullOrEmpty(responseContent))
                            errorResponse = JsonConvert.DeserializeObject<TraktCheckinPostErrorResponse>(responseContent);

                        throw new TraktCheckinException("checkin is already in progress")
                        {
                            RequestUrl = Url,
                            RequestBody = RequestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = response.ReasonPhrase,
                            ExpiresAt = errorResponse?.ExpiresAt
                        };
                    }

                    throw new TraktConflictException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case HttpStatusCode.InternalServerError:
                    throw new TraktServerException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case HttpStatusCode.BadGateway:
                    throw new TraktBadGatewayException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case (HttpStatusCode)412:
                    throw new TraktPreconditionFailedException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case (HttpStatusCode)422:
                    throw new TraktValidationException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case (HttpStatusCode)429:
                    throw new TraktRateLimitException()
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case (HttpStatusCode)503:
                case (HttpStatusCode)504:
                    throw new TraktServerUnavailableException("Service Unavailable - server overloaded (try again in 30s)")
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        StatusCode = HttpStatusCode.ServiceUnavailable,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
                case (HttpStatusCode)520:
                case (HttpStatusCode)521:
                case (HttpStatusCode)522:
                    throw new TraktServerUnavailableException("Service Unavailable - Cloudflare error")
                    {
                        RequestUrl = Url,
                        RequestBody = RequestBodyJson,
                        StatusCode = HttpStatusCode.ServiceUnavailable,
                        Response = responseContent,
                        ServerReasonPhrase = response.ReasonPhrase
                    };
            }

            TraktError error = null;

            try
            {
                error = JsonConvert.DeserializeObject<TraktError>(responseContent);
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
                RequestUrl = Url,
                RequestBody = RequestBodyJson,
                Response = responseContent,
                ServerReasonPhrase = response.ReasonPhrase
            };
        }
    }
}
