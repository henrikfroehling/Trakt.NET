namespace TraktNet.Requests.Handler
{
    using Authentication;
    using Core;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Interfaces.Base;
    using Objects.Authentication;
    using Objects.Basic;
    using Objects.Json;
    using Responses;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal sealed class AuthenticationRequestHandler : IAuthenticationRequestHandler
    {
        private readonly TraktClient _client;
        private static IAuthenticationRequestHandler s_requestHandler;

        internal AuthenticationRequestHandler(TraktClient client)
        {
            _client = client;
        }

        internal static IAuthenticationRequestHandler GetInstance(TraktClient client)
            => s_requestHandler ??= new AuthenticationRequestHandler(client);

        public string CreateAuthorizationUrl(string clientId, string redirectUri, string state = null)
        {
            ValidateAuthorizationUrlArguments(clientId, redirectUri, state);
            return BuildAuthorizationUrl(clientId, redirectUri, state);
        }

        public string CreateAuthorizationUrlWithDefaultState(string clientId, string redirectUri)
        {
            string state = _client.Authentication.AntiForgeryToken;
            return CreateAuthorizationUrl(clientId, redirectUri, state);
        }

        public async Task<Pair<bool, TraktResponse<ITraktAuthorization>>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(bool autoRefresh = false, CancellationToken cancellationToken = default)
        {
            if (_client.Authorization.IsExpired)
                return new Pair<bool, TraktResponse<ITraktAuthorization>>(true, new TraktResponse<ITraktAuthorization>());

            bool throwResponseExceptions = true;

            try
            {
                throwResponseExceptions = _client.Configuration.ThrowResponseExceptions;
                _client.Configuration.ThrowResponseExceptions = true;
                await _client.Sync.GetLastActivitiesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (TraktAuthorizationException)
            {
                if (!autoRefresh)
                    return new Pair<bool, TraktResponse<ITraktAuthorization>>(true, new TraktResponse<ITraktAuthorization>());

                var request = new AuthorizationRefreshRequest
                {
                    RequestBody = new AuthorizationRefreshRequestBody
                    {
                        ClientId = _client.ClientId,
                        ClientSecret = _client.ClientSecret,
                        RefreshToken = _client.Authorization.RefreshToken,
                        RedirectUri = _client.Authentication.RedirectUri
                    }
                };

                TraktResponse<ITraktAuthorization> response = await RefreshAuthorizationAsync(request, cancellationToken).ConfigureAwait(false);
                return new Pair<bool, TraktResponse<ITraktAuthorization>>(response.IsSuccess, response);
            }
            finally
            {
                _client.Configuration.ThrowResponseExceptions = throwResponseExceptions;
            }

            return new Pair<bool, TraktResponse<ITraktAuthorization>>(false, new TraktResponse<ITraktAuthorization>());
        }

        public async Task<Pair<bool, TraktResponse<ITraktAuthorization>>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(ITraktAuthorization authorization, bool autoRefresh = false, CancellationToken cancellationToken = default)
        {
            ITraktAuthorization currentAuthorization = _client.Authorization;
            _client.Authorization = authorization ?? throw new ArgumentNullException(nameof(authorization));

            var result = new Pair<bool, TraktResponse<ITraktAuthorization>>(true, new TraktResponse<ITraktAuthorization>());

            try
            {
                result = await CheckIfAuthorizationIsExpiredOrWasRevokedAsync(autoRefresh, cancellationToken).ConfigureAwait(false);

                if (result.First && autoRefresh && result.Second.IsSuccess)
                    _client.Authorization = result.Second.Value;
            }
            finally
            {
                if (!result.First)
                    _client.Authorization = currentAuthorization;
            }

            return result;
        }

        public Task<bool> CheckIfAccessTokenWasRevokedOrIsNotValidAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(accessToken) || accessToken.ContainsSpace())
                throw new ArgumentException("access token must not be null, empty or contain any spaces", nameof(accessToken));

            return InternalCheckIfAccessTokenWasRevokedOrIsNotValidAsync(accessToken, cancellationToken);
        }

        private async Task<bool> InternalCheckIfAccessTokenWasRevokedOrIsNotValidAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            ITraktAuthorization currentAuthorization = _client.Authorization;
            _client.Authorization = TraktAuthorization.CreateWith(accessToken);

            bool throwResponseExceptions = true;

            try
            {
                throwResponseExceptions = _client.Configuration.ThrowResponseExceptions;
                _client.Configuration.ThrowResponseExceptions = true;
                await _client.Sync.GetLastActivitiesAsync(cancellationToken).ConfigureAwait(false);
                return false;
            }
            catch (TraktAuthorizationException)
            {
                return true;
            }
            finally
            {
                _client.Configuration.ThrowResponseExceptions = throwResponseExceptions;
                _client.Authorization = currentAuthorization;
            }
        }

        public async Task<TraktResponse<ITraktDevice>> GetDeviceAsync(DeviceRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                request.Validate();

                var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
                ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build().ConfigureAwait(false);

                HttpResponseMessage responseMessage = await _client.HttpClientProvider.GetHttpClient(_client.ClientId).SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

                if (!responseMessage.IsSuccessStatusCode)
                    await ResponseErrorHandler.HandleErrorsAsync(requestMessage, responseMessage, isDeviceRequest: true, cancellationToken: cancellationToken).ConfigureAwait(false);

                DebugAsserter.AssertResponseMessageIsNotNull(responseMessage);
                DebugAsserter.AssertHttpResponseCodeIsExpected(responseMessage.StatusCode, HttpStatusCode.OK, DebugAsserter.SINGLE_ITEM_RESPONSE_PRECONDITION_INVALID_STATUS_CODE);

                Stream responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                IObjectJsonReader<ITraktDevice> objectJsonReader = JsonFactoryContainer.CreateObjectReader<ITraktDevice>();
                ITraktDevice device = await objectJsonReader.ReadObjectAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                var response = new TraktResponse<ITraktDevice>()
                {
                    Value = device,
                    HasValue = device != null,
                    IsSuccess = device != null
                };

                if (responseMessage.Headers != null)
                    ResponseHeaderParser.ParseResponseHeaderValues(response, responseMessage.Headers);

                _client.Authentication.Device = device;
                return response;
            }
            catch (Exception ex)
            {
                if (_client.Configuration.ThrowResponseExceptions)
                    throw;

                return new TraktResponse<ITraktDevice> { IsSuccess = false, Exception = ex };
            }
        }

        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(AuthorizationRequest request, CancellationToken cancellationToken = default)
            => ExecuteAuthorizationRequestAsync(request, false, cancellationToken);

        public async Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(AuthorizationPollRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                request.Validate();

                var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
                ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build().ConfigureAwait(false);

                HttpResponseMessage responseMessage;
                Stream responseContentStream;
                HttpStatusCode responseCode;
                string reasonPhrase = string.Empty;
                uint totalExpiredSeconds = 0;
                ITraktDevice device = request.RequestBody.Device;
                IObjectJsonReader<ITraktAuthorization> objectJsonReader = JsonFactoryContainer.CreateObjectReader<ITraktAuthorization>();

                while (totalExpiredSeconds < device.ExpiresInSeconds)
                {
                    responseMessage = await _client.HttpClientProvider.GetHttpClient(_client.ClientId).SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

                    responseCode = responseMessage.StatusCode;
                    reasonPhrase = responseMessage.ReasonPhrase;

                    if (responseCode == HttpStatusCode.OK) // Success
                    {
                        responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                        ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                        var response = new TraktResponse<ITraktAuthorization>()
                        {
                            Value = traktAuthorization,
                            HasValue = traktAuthorization != null,
                            IsSuccess = traktAuthorization != null
                        };

                        if (responseMessage.Headers != null)
                            ResponseHeaderParser.ParseResponseHeaderValues(response, responseMessage.Headers);

                        _client.Authentication.Authorization = traktAuthorization;
                        return response;
                    }
                    else if (responseCode == HttpStatusCode.BadRequest) // Pending
                    {
                        await Task.Delay((int)device.IntervalInMilliseconds).ConfigureAwait(false);
                        totalExpiredSeconds += device.IntervalInSeconds;

                        requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
                        requestMessage = await requestMessageBuilder.Build().ConfigureAwait(false);
                        continue;
                    }

                    await ResponseErrorHandler.HandleErrorsAsync(requestMessage, responseMessage, isInAuthorizationPolling: true, cancellationToken: cancellationToken).ConfigureAwait(false);
                    break;
                }

                throw new TraktAuthenticationDeviceException("unknown exception")
                {
                    RequestUrl = requestMessage.Url,
                    RequestBody = requestMessage.RequestBodyJson,
                    ServerReasonPhrase = reasonPhrase
                };
            }
            catch (Exception ex)
            {
                if (_client.Configuration.ThrowResponseExceptions)
                    throw;

                return new TraktResponse<ITraktAuthorization> { IsSuccess = false, Exception = ex };
            }
        }

        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(AuthorizationRefreshRequest request, CancellationToken cancellationToken = default)
            => ExecuteAuthorizationRequestAsync(request, true, cancellationToken);

        public async Task<TraktNoContentResponse> RevokeAuthorizationAsync(AuthorizationRevokeRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                request.Validate();

                var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
                ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build().ConfigureAwait(false);

                HttpResponseMessage responseMessage = await _client.HttpClientProvider.GetHttpClient(_client.ClientId).SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

                if (!responseMessage.IsSuccessStatusCode)
                {
                    if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        string responseContent = responseMessage.Content != null ? await responseMessage.Content.ReadAsStringAsync().ConfigureAwait(false) : string.Empty;

                        throw new TraktAuthenticationException("error on revoking access token")
                        {
                            RequestUrl = requestMessage.Url,
                            RequestBody = requestMessage.RequestBodyJson,
                            Response = responseContent,
                            ServerReasonPhrase = responseMessage.ReasonPhrase
                        };
                    }

                    await ResponseErrorHandler.HandleErrorsAsync(requestMessage, responseMessage, isAuthorizationRevoke: true, cancellationToken: cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    _client.Authorization = TraktAuthorization.CreateWith(string.Empty, string.Empty);

                    return new TraktNoContentResponse
                    {
                        IsSuccess = true
                    };
                }

                throw new TraktAuthenticationException("unknown exception")
                {
                    RequestUrl = requestMessage.Url,
                    RequestBody = requestMessage.RequestBodyJson,
                    StatusCode = responseMessage.StatusCode,
                    ServerReasonPhrase = responseMessage.ReasonPhrase
                };
            }
            catch (Exception ex)
            {
                if (_client.Configuration.ThrowResponseExceptions)
                    throw;

                return new TraktNoContentResponse { IsSuccess = false, Exception = ex };
            }
        }

        private async Task<TraktResponse<ITraktAuthorization>> ExecuteAuthorizationRequestAsync<TRequestBodyType>(IPostRequest<ITraktAuthorization, TRequestBodyType> request, bool isRefreshRequest, CancellationToken cancellationToken = default) where TRequestBodyType : IRequestBody
        {
            try
            {
                request.Validate();

                var requestMessageBuilder = CreateRequestMessageBuilder(request, request.RequestBody);
                ExtendedHttpRequestMessage requestMessage = await requestMessageBuilder.Build().ConfigureAwait(false);

                HttpResponseMessage responseMessage = await _client.HttpClientProvider.GetHttpClient(_client.ClientId).SendAsync(requestMessage, cancellationToken).ConfigureAwait(false);

                HttpStatusCode responseCode = responseMessage.StatusCode;
                Stream responseContentStream;

                if (responseCode == HttpStatusCode.OK)
                {
                    responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                    IObjectJsonReader<ITraktAuthorization> objectJsonReader = JsonFactoryContainer.CreateObjectReader<ITraktAuthorization>();
                    ITraktAuthorization traktAuthorization = await objectJsonReader.ReadObjectAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                    var response = new TraktResponse<ITraktAuthorization>()
                    {
                        Value = traktAuthorization,
                        HasValue = traktAuthorization != null,
                        IsSuccess = traktAuthorization != null
                    };

                    if (responseMessage.Headers != null)
                        ResponseHeaderParser.ParseResponseHeaderValues(response, responseMessage.Headers);

                    _client.Authentication.Authorization = traktAuthorization;
                    return response;
                }
                else if (responseCode == HttpStatusCode.Unauthorized) // Invalid code
                {
                    responseContentStream = await ResponseMessageHelper.GetResponseContentStreamAsync(responseMessage).ConfigureAwait(false);
                    IObjectJsonReader<ITraktError> objectJsonReader = JsonFactoryContainer.CreateObjectReader<ITraktError>();
                    ITraktError traktError = await objectJsonReader.ReadObjectAsync(responseContentStream, cancellationToken).ConfigureAwait(false);

                    string errorMessage = "unknown error";

                    if (traktError != null)
                    {
                        string actionString = "retrieving";

                        if (isRefreshRequest)
                            actionString = "refreshing";

                        errorMessage = $"error on {actionString} oauth access token\nerror: {traktError.Error}\ndescription: {traktError.Description}";
                    }

                    throw new TraktAuthenticationOAuthException(errorMessage)
                    {
                        StatusCode = responseCode,
                        RequestUrl = requestMessage.Url,
                        RequestBody = requestMessage.RequestBodyJson,
                        ServerReasonPhrase = responseMessage.ReasonPhrase
                    };
                }

                await ResponseErrorHandler.HandleErrorsAsync(requestMessage, responseMessage, isAuthorizationRequest: true, cancellationToken: cancellationToken).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                if (_client.Configuration.ThrowResponseExceptions)
                    throw;

                return new TraktResponse<ITraktAuthorization> { IsSuccess = false, Exception = ex };
            }

            return new TraktResponse<ITraktAuthorization>();
        }

        private string CreateEncodedAuthorizationUri(string clientId, string redirectUri, string state = null)
        {
            var uriParams = new Dictionary<string, string>
            {
                ["response_type"] = "code",
                ["client_id"] = clientId,
                ["redirect_uri"] = redirectUri
            };

            if (!string.IsNullOrEmpty(state))
                uriParams["state"] = state;

            var encodedUriContent = new FormUrlEncodedContent(uriParams);
            string encodedUri = encodedUriContent.ReadAsStringAsync().Result;

            if (string.IsNullOrEmpty(encodedUri))
                throw new ArgumentException("authorization uri not valid");

            return $"?{encodedUri}";
        }

        private string BuildAuthorizationUrl(string clientId, string redirectUri, string state = null)
        {
            string encodedUriParams = CreateEncodedAuthorizationUri(clientId, redirectUri, state);
            bool isStagingUsed = _client.Configuration.UseSandboxEnvironment;
            string baseUrl = isStagingUsed ? Constants.OAuthBaseAuthorizeStagingUrl : Constants.OAuthBaseAuthorizeUrl;
            return $"{baseUrl}/{Constants.OAuthAuthorizeUri}{encodedUriParams}";
        }

        private void ValidateAuthorizationUrlArguments(string clientId, string redirectUri)
        {
            if (string.IsNullOrEmpty(clientId) || clientId.ContainsSpace())
                throw new ArgumentException("client id not valid", nameof(clientId));

            if (string.IsNullOrEmpty(redirectUri) || redirectUri.ContainsSpace())
                throw new ArgumentException("redirect uri not valid", nameof(redirectUri));
        }

        private void ValidateAuthorizationUrlArguments(string clientId, string redirectUri, string state)
        {
            ValidateAuthorizationUrlArguments(clientId, redirectUri);

            if (state != null && (state.Length == 0 || state.ContainsSpace()))
                throw new ArgumentException("state not valid", nameof(state));
        }

        private RequestMessageBuilder CreateRequestMessageBuilder(IRequest request = null, IRequestBody requestBody = null)
            => new RequestMessageBuilder(_client.ClientId, _client.Configuration.ApiVersion, _client.Configuration.BaseUrl,
                                         _client.Authentication.Authorization.AccessToken, _client.Authentication.IsAuthorized,
                                         _client.Configuration.ForceAuthorization)
               {
                    UseAPIVersionHeader = false,
                    UseAPIClientIdHeader = false,
                    Request = request,
                    RequestBody = requestBody
               };
    }
}
