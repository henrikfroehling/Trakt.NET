namespace TraktApiSharp.Requests.Base
{
    using Exceptions;
    using Newtonsoft.Json;
    using Objects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;

    internal abstract class TraktRequest<TResult, TItem> : ITraktRequest<TResult, TItem>
    {
        private static string HEADER_PAGINATION_PAGE_KEY = "X-Pagination-Page";
        private static string HEADER_PAGINATION_LIMIT_KEY = "X-Pagination-Limit";
        private static string HEADER_PAGINATION_PAGE_COUNT_KEY = "X-Pagination-Page-Count";
        private static string HEADER_PAGINATION_ITEM_COUNT_KEY = "X-Pagination-Item-Count";

        private static HttpClient HTTP_CLIENT = null;

        protected TraktRequest(TraktClient client)
        {
            Client = client;
            PaginationOptions = new TraktPaginationOptions();
        }

        internal TraktClient Client { get; private set; }

        protected abstract string UriTemplate { get; }

        protected abstract TraktAuthenticationRequirement AuthenticationRequirement { get; }

        internal string Id { get; set; }

        protected abstract TraktRequestObjectType RequestObjectType { get; }

        internal virtual int Season { get; set; }

        internal virtual int Episode { get; set; }

        protected abstract bool IsListResult { get; }

        internal TraktExtendedOption ExtendedOption { get; set; }

        protected virtual bool SupportsPagination => false;

        protected abstract HttpMethod Method { get; }

        internal TraktPaginationOptions PaginationOptions { get; set; }

        private bool _authenticationHeaderRequired;

        internal bool AuthenticationHeaderRequired
        {
            get
            {
                if (AuthenticationRequirement == TraktAuthenticationRequirement.Required)
                    return true;

                if (AuthenticationRequirement == TraktAuthenticationRequirement.Forbidden)
                    return false;

                return _authenticationHeaderRequired;
            }

            set
            {
                if (!value && AuthenticationRequirement == TraktAuthenticationRequirement.Required)
                    throw new InvalidOperationException("request type requires authentication");

                if (!value && AuthenticationRequirement == TraktAuthenticationRequirement.Forbidden)
                    throw new InvalidOperationException("request type does not allow authentication");

                _authenticationHeaderRequired = value;
            }
        }

        protected virtual IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string>();
        }

        private string UriPath
        {
            get
            {
                return GetPathParameters()
                    .Aggregate(UriTemplate.ToLower(),
                               (current, parameter) => current.Replace($"{{{parameter.Key.ToLower()}}}", parameter.Value.ToLower()))
                    .TrimEnd(new[] { '/' });
            }
        }

        protected virtual IEnumerable<KeyValuePair<string, string>> GetExtendedOptionParameters()
        {
            var optionParams = new Dictionary<string, string>();

            if (ExtendedOption != TraktExtendedOption.Unspecified)
                optionParams["extended"] = ExtendedOption.AsString();

            if (SupportsPagination)
            {
                if (PaginationOptions.Page != null)
                    optionParams["page"] = PaginationOptions.Page.ToString();

                if (PaginationOptions.Limit != null)
                    optionParams["limit"] = PaginationOptions.Limit.ToString();
            }

            return optionParams;
        }

        private string OptionParameters
        {
            get
            {
                using (var content = new FormUrlEncodedContent(GetExtendedOptionParameters()))
                {
                    var ret = content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(ret))
                        ret = $"?{ret}";

                    return ret;
                }
            }
        }

        internal object RequestBody { get; set; }

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
                    Formatting = Formatting.Indented,
                    NullValueHandling = NullValueHandling.Ignore
                });
            }
        }

        internal string Url => $"{Client.Configuration.BaseUrl}{UriPath}{OptionParameters}";

        protected virtual void Validate() { }

        protected virtual void SetRequestHeadersForAuthentication(HttpRequestMessage request)
        {
            if (AuthenticationHeaderRequired)
            {
                if (!Client.Authentication.IsAuthenticated)
                    throw new IndexOutOfRangeException("authentication is required for this request, but the current authentication parameters are invalid");

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Client.Authentication.AccessToken.AccessToken);
            }
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("trakt-api-key", Client.ClientId);
            httpClient.DefaultRequestHeaders.Add("trakt-api-version", $"{Client.Configuration.ApiVersion}");

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<TResult> QueryAsync()
        {
            Validate();

            if (HTTP_CLIENT == null)
            {
                HTTP_CLIENT = new HttpClient();
                SetDefaultRequestHeaders(HTTP_CLIENT);
            }

            using (var request = new HttpRequestMessage(Method, Url) { Content = RequestBodyContent })
            {
                SetRequestHeadersForAuthentication(request);

                using (var response = await HTTP_CLIENT.SendAsync(request))
                {
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Error handling
                    if (!response.IsSuccessStatusCode)
                        ErrorHandling(response, responseContent);

                    // No content
                    if (string.IsNullOrEmpty(responseContent) || response.StatusCode == HttpStatusCode.NoContent)
                        return default(TResult);

                    // Handle list result
                    if (IsListResult)
                        return await HandleListResult(response, responseContent);

                    // Single object item
                    return await Task.Run(() => JsonConvert.DeserializeObject<TResult>(responseContent));
                }
            }
        }

        private async Task<TResult> HandleListResult(HttpResponseMessage response, string responseContent)
        {
            if (SupportsPagination)
            {
                if (typeof(TResult) != typeof(TraktPaginationListResult<TItem>))
                    throw new InvalidCastException("TResult cannot be converted as TraktPaginationListResult<TItem>");

                var typePaginationElement = typeof(TResult).GenericTypeArguments[0];
                var typePaginationList = typeof(TraktPaginationListResult<>).MakeGenericType(typePaginationElement);
                var paginationListResult = Activator.CreateInstance(typePaginationList);

                (paginationListResult as TraktPaginationListResult<TItem>).Items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<TItem>>(responseContent));

                var headers = response.Headers;
                IEnumerable<string> values;

                if (headers.TryGetValues(HEADER_PAGINATION_PAGE_KEY, out values))
                {
                    var strPage = values.First();
                    int page;

                    if (Int32.TryParse(strPage, out page))
                        (paginationListResult as TraktPaginationListResult<TItem>).Page = page;
                }

                if (headers.TryGetValues(HEADER_PAGINATION_LIMIT_KEY, out values))
                {
                    var strLimit = values.First();
                    int limit;

                    if (Int32.TryParse(strLimit, out limit))
                        (paginationListResult as TraktPaginationListResult<TItem>).Limit = limit;
                }

                if (headers.TryGetValues(HEADER_PAGINATION_PAGE_COUNT_KEY, out values))
                {
                    var strPageCount = values.First();
                    int pageCount;

                    if (Int32.TryParse(strPageCount, out pageCount))
                        (paginationListResult as TraktPaginationListResult<TItem>).PageCount = pageCount;
                }

                if (headers.TryGetValues(HEADER_PAGINATION_ITEM_COUNT_KEY, out values))
                {
                    var strItemCount = values.First();
                    int itemCount;

                    if (Int32.TryParse(strItemCount, out itemCount))
                        (paginationListResult as TraktPaginationListResult<TItem>).ItemCount = itemCount;
                }

                return (TResult)paginationListResult;
            }

            if (typeof(TResult) != typeof(TraktListResult<TItem>))
                throw new InvalidCastException("TResult cannot be converted as TraktListResult<TItem>");

            var typeElement = typeof(TResult).GenericTypeArguments[0];
            var typeList = typeof(TraktListResult<>).MakeGenericType(typeElement);
            var listResult = Activator.CreateInstance(typeList);

            (listResult as TraktListResult<TItem>).Items = await Task.Run(() => JsonConvert.DeserializeObject<IEnumerable<TItem>>(responseContent));

            return (TResult)listResult;
        }

        private void ErrorHandling(HttpResponseMessage response, string responseContent)
        {
            var code = response.StatusCode;

            TraktError error = null;

            try
            {
                error = JsonConvert.DeserializeObject<TraktError>(responseContent);
            }
            catch { }

            var errorMessage = (error == null || string.IsNullOrEmpty(error.Description))
                                    ? $"Trakt API error without content. Response status code was {(int)code}"
                                    : error.Description;

            switch (code)
            {
                case HttpStatusCode.NotFound:
                    {
                        switch (RequestObjectType)
                        {
                            case TraktRequestObjectType.Episodes:
                                throw new TraktEpisodeNotFoundException(Id, Season, Episode)
                                { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                            case TraktRequestObjectType.Seasons:
                                throw new TraktSeasonNotFoundException(Id, Season)
                                { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                            case TraktRequestObjectType.Shows:
                                throw new TraktShowNotFoundException(Id)
                                { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                            case TraktRequestObjectType.Movies:
                                throw new TraktMovieNotFoundException(Id)
                                { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                            case TraktRequestObjectType.Unspecified:
                            default:
                                throw new TraktObjectNotFoundException(Id)
                                { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                        }
                    }
                case HttpStatusCode.BadRequest:
                    throw new TraktBadRequestException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case HttpStatusCode.Unauthorized:
                    throw new TraktBadRequestException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case HttpStatusCode.Forbidden:
                    throw new TraktForbiddenException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case HttpStatusCode.MethodNotAllowed:
                    throw new TraktMethodNotFoundException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case HttpStatusCode.Conflict:
                    throw new TraktConflictException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case HttpStatusCode.InternalServerError:
                    throw new TraktServerException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case HttpStatusCode.BadGateway:
                    throw new TraktBadGatewayException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case (HttpStatusCode)422:
                    throw new TraktValidationException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case (HttpStatusCode)429:
                    throw new TraktRateLimitException()
                    { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
                case (HttpStatusCode)503:
                case (HttpStatusCode)504:
                    throw new TraktServerUnavailableException("Service Unavailable - server overloaded (try again in 30s)")
                    { RequestUrl = Url, RequestBody = RequestBodyJson, StatusCode = HttpStatusCode.ServiceUnavailable, Response = responseContent };
                case (HttpStatusCode)520:
                case (HttpStatusCode)521:
                case (HttpStatusCode)522:
                    throw new TraktServerUnavailableException("Service Unavailable - Cloudflare error")
                    { RequestUrl = Url, RequestBody = RequestBodyJson, StatusCode = HttpStatusCode.ServiceUnavailable, Response = responseContent };
            }

            throw new TraktException(errorMessage)
            { RequestUrl = Url, RequestBody = RequestBodyJson, Response = responseContent };
        }
    }
}
