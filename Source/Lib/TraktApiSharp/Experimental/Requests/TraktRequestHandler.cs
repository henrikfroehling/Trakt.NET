namespace TraktApiSharp.Experimental.Requests
{
    using Core;
    using Exceptions;
    using Interfaces;
    using Interfaces.Base;
    using Responses;
    using Responses.Interfaces;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading.Tasks;
    using TraktApiSharp.Requests;
    using UriTemplates;
    using Utils;

    internal sealed class TraktRequestHandler : ITraktRequestHandler
    {
        internal static HttpClient s_httpClient;

        private TraktClient _client;

        internal TraktRequestHandler(TraktClient client)
        {
            _client = client;
        }

        public async Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync(ITraktRequest request)
        {
            PreExecuteRequest(request);
            return await QueryNoContentAsync(SetupRequestMessage(request));
        }

        public async Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType>(ITraktRequest<TContentType> request)
        {
            PreExecuteRequest(request);
            return await QuerySingleItemAsync<TContentType>(SetupRequestMessage(request));
        }

        public async Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType>(ITraktRequest<TContentType> request)
        {
            PreExecuteRequest(request);
            return await QueryListAsync<TContentType>(SetupRequestMessage(request));
        }

        public async Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType>(ITraktRequest<TContentType> request)
        {
            PreExecuteRequest(request);
            return await QueryPagedListAsync<TContentType>(SetupRequestMessage(request));
        }

        // post requests

        public async Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPostRequest<TRequestBody> request)
        {
            PreExecuteRequest(request);
            return await QueryNoContentAsync(SetupRequestMessage(request));
        }

        public async Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request)
        {
            PreExecuteRequest(request);
            return await QuerySingleItemAsync<TContentType>(SetupRequestMessage(request));
        }

        public async Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request)
        {
            PreExecuteRequest(request);
            return await QueryListAsync<TContentType>(SetupRequestMessage(request));
        }

        public async Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request)
        {
            PreExecuteRequest(request);
            return await QueryPagedListAsync<TContentType>(SetupRequestMessage(request));
        }

        // put requests

        public async Task<ITraktNoContentResponse> ExecuteNoContentRequestAsync<TRequestBody>(ITraktPutRequest<TRequestBody> request)
        {
            PreExecuteRequest(request);
            return await QueryNoContentAsync(SetupRequestMessage(request));
        }

        public async Task<ITraktResponse<TContentType>> ExecuteSingleItemRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request)
        {
            PreExecuteRequest(request);
            return await QuerySingleItemAsync<TContentType>(SetupRequestMessage(request));
        }

        public async Task<ITraktListResponse<TContentType>> ExecuteListRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request)
        {
            PreExecuteRequest(request);
            return await QueryListAsync<TContentType>(SetupRequestMessage(request));
        }

        public async Task<ITraktPagedResponse<TContentType>> ExecutePagedRequestAsync<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request)
        {
            PreExecuteRequest(request);
            return await QueryPagedListAsync<TContentType>(SetupRequestMessage(request));
        }

        // query response helper methods

        private async Task<ITraktNoContentResponse> QueryNoContentAsync(HttpRequestMessage requestMessage)
        {
            var responseContent = await ExecuteRequestAsync(requestMessage);
            return await Task.FromResult(new TraktNoContentResponse());
        }

        private async Task<ITraktResponse<TContentType>> QuerySingleItemAsync<TContentType>(HttpRequestMessage requestMessage)
        {
            var responseContent = await ExecuteRequestAsync(requestMessage);
            return await Task.FromResult(new TraktResponse<TContentType>());
        }

        private async Task<ITraktListResponse<TContentType>> QueryListAsync<TContentType>(HttpRequestMessage requestMessage)
        {
            var responseContent = await ExecuteRequestAsync(requestMessage);
            return await Task.FromResult(new TraktListResponse<TContentType>());
        }

        private async Task<ITraktPagedResponse<TContentType>> QueryPagedListAsync<TContentType>(HttpRequestMessage requestMessage)
        {
            var responseContent = await ExecuteRequestAsync(requestMessage);
            return await Task.FromResult(new TraktPagedResponse<TContentType>());
        }
        
        private async Task<string> ExecuteRequestAsync(HttpRequestMessage requestMessage)
        {
            var response = await s_httpClient.SendAsync(requestMessage).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                // error handling
            }

            return response.Content != null
                ? await response.Content.ReadAsStringAsync().ConfigureAwait(false)
                : string.Empty;
        }

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
            var httpClient = s_httpClient ?? new HttpClient();
            SetDefaultRequestHeaders(httpClient);
        }

        private string BuildUrl(ITraktRequest request)
        {
            var uriTemplate = new UriTemplate(request.UriTemplate);
            var requestUriParameters = request.GetUriPathParameters();

            foreach (var parameter in requestUriParameters)
                uriTemplate.AddParameterFromKeyValuePair(parameter.Key, parameter.Value);

            var uri = uriTemplate.Resolve();
            return $"{_client.Configuration.BaseUrl}{uri}";
        }

        private HttpRequestMessage SetupRequestMessage(ITraktRequest request)
        {
            var requestMessage = CreateRequestMessage(request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private HttpRequestMessage SetupRequestMessage<TRequestBody>(ITraktPostRequest<TRequestBody> request)
        {
            var requestMessage = CreateRequestMessage(request);
            AddRequestBodyContent(requestMessage, request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private HttpRequestMessage SetupRequestMessage<TContentType, TRequestBody>(ITraktPostRequest<TContentType, TRequestBody> request)
        {
            var requestMessage = CreateRequestMessage(request);
            AddRequestBodyContent(requestMessage, request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private HttpRequestMessage SetupRequestMessage<TRequestBody>(ITraktPutRequest<TRequestBody> request)
        {
            var requestMessage = CreateRequestMessage(request);
            AddRequestBodyContent(requestMessage, request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private HttpRequestMessage SetupRequestMessage<TContentType, TRequestBody>(ITraktPutRequest<TContentType, TRequestBody> request)
        {
            var requestMessage = CreateRequestMessage(request);
            AddRequestBodyContent(requestMessage, request);
            SetRequestMessageHeadersForAuthorization(requestMessage, request.AuthorizationRequirement);
            return requestMessage;
        }

        private HttpContent GetRequestBodyContent<TRequestBody>(ITraktHasRequestBody<TRequestBody> request)
        {
            var requestBody = request.RequestBody;

            if (requestBody == null)
                return null;

            var json = Json.Serialize(requestBody);
            return !string.IsNullOrEmpty(json) ? new StringContent(json, Encoding.UTF8, "application/json") : null;
        }

        private HttpRequestMessage CreateRequestMessage(ITraktRequest request)
        {
            var url = BuildUrl(request);
            return new HttpRequestMessage(request.Method, url);
        }

        private void AddRequestBodyContent<TRequestBody>(HttpRequestMessage requestMessage, ITraktHasRequestBody<TRequestBody> request)
        {
            if (requestMessage == null)
                throw new ArgumentNullException(nameof(requestMessage));

            requestMessage.Content = GetRequestBodyContent(request);
        }

        private void SetDefaultRequestHeaders(HttpClient httpClient)
        {
            var appJsonHeader = new MediaTypeWithQualityHeaderValue("application/json");

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIClientIdHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIClientIdHeaderKey, _client.ClientId);

            if (!httpClient.DefaultRequestHeaders.Contains(TraktConstants.APIVersionHeaderKey))
                httpClient.DefaultRequestHeaders.Add(TraktConstants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");

            if (!httpClient.DefaultRequestHeaders.Accept.Contains(appJsonHeader))
                httpClient.DefaultRequestHeaders.Accept.Add(appJsonHeader);
        }

        private void SetRequestMessageHeadersForAuthorization(HttpRequestMessage requestMessage, TraktAuthorizationRequirement authorizationRequirement)
        {
            if (requestMessage == null)
                throw new ArgumentNullException(nameof(requestMessage));

            if (authorizationRequirement == TraktAuthorizationRequirement.Required)
            {
                if (!_client.Authentication.IsAuthorized)
                    throw new TraktAuthorizationException("authorization is required for this request, but the current authorization parameters are invalid");

                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _client.Authentication.Authorization.AccessToken);
            }

            if (authorizationRequirement == TraktAuthorizationRequirement.Optional && _client.Configuration.ForceAuthorization && _client.Authentication.IsAuthorized)
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _client.Authentication.Authorization.AccessToken);
        }
    }
}
