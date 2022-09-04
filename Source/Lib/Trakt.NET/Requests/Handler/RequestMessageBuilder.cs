namespace TraktNet.Requests.Handler
{
    using Base;
    using Core;
    using Exceptions;
    using Interfaces;
    using Interfaces.Base;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RequestMessageBuilder
    {
        private const string AUTHENTICATION_SCHEME = "Bearer";
        private const string SEASON_KEY = "season";
        private const string EPISODE_KEY = "episode";

        private IRequest _request;
        private IRequestBody _requestBody;
        private readonly TraktClient _client;
        private bool _useAPIVersionHeader;
        private bool _useAPIClientIdHeader;

        internal RequestMessageBuilder(TraktClient client)
        {
            _useAPIVersionHeader = true;
            _useAPIClientIdHeader = true;
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        internal RequestMessageBuilder(IRequest request, TraktClient client) : this(client) => _request = request;

        internal RequestMessageBuilder WithRequestBody(IRequestBody requestBody)
        {
            _requestBody = requestBody;
            return this;
        }

        internal RequestMessageBuilder Reset(IRequest request)
        {
            _useAPIVersionHeader = true;
            _useAPIClientIdHeader = true;
            _request = request;
            _requestBody = null;
            return this;
        }

        internal RequestMessageBuilder DisableAPIVersionHeader()
        {
            _useAPIVersionHeader = false;
            return this;
        }

        internal RequestMessageBuilder EnableAPIVersionHeader()
        {
            _useAPIVersionHeader = true;
            return this;
        }

        internal RequestMessageBuilder DisableAPIClientIdHeader()
        {
            _useAPIClientIdHeader = false;
            return this;
        }

        internal RequestMessageBuilder EnableAPIClientIdHeader()
        {
            _useAPIClientIdHeader = true;
            return this;
        }

        internal async Task<ExtendedHttpRequestMessage> Build(CancellationToken cancellationToken = default)
        {
            ExtendedHttpRequestMessage requestMessage = CreateRequestMessage();
            await AddRequestBodyContent(requestMessage, cancellationToken).ConfigureAwait(false);
            SetRequestMessageHeaders(requestMessage);
            return requestMessage;
        }

        private ExtendedHttpRequestMessage CreateRequestMessage()
        {
            if (_request == null)
                throw new ArgumentNullException(nameof(_request));

            string url = BuildUrl();

            var requestMessage = new ExtendedHttpRequestMessage(_request.Method, url)
            {
                Url = url
            };

            if (_request is IHasId)
            {
                var idRequest = _request as IHasId;

                requestMessage.ObjectId = idRequest?.Id;
                requestMessage.RequestObjectType = idRequest?.RequestObjectType;
            }

            IDictionary<string, object> requestUriParameters = _request.GetUriPathParameters();

            if (requestUriParameters.Count != 0)
            {
                if (requestUriParameters.ContainsKey(SEASON_KEY))
                {
                    var strSeasonNumber = (string)requestUriParameters[SEASON_KEY];

                    if (uint.TryParse(strSeasonNumber, out uint seasonNumber))
                        requestMessage.SeasonNumber = seasonNumber;
                }

                if (requestUriParameters.ContainsKey(EPISODE_KEY))
                {
                    var strEpisodeNumber = (string)requestUriParameters[EPISODE_KEY];

                    if (uint.TryParse(strEpisodeNumber, out uint episodeNumber))
                        requestMessage.EpisodeNumber = episodeNumber;
                }
            }

            return requestMessage;
        }

        private string BuildUrl()
        {
            var requestUri = new RequestUri(_request.UriTemplate, _request.GetUriPathParameters());
            string url = requestUri.ResolveUrl();
            return _client.Configuration.BaseUrl + url;
        }

        private async Task AddRequestBodyContent(ExtendedHttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            if (_requestBody != null)
            {
                string json = await _requestBody.ToJson(cancellationToken).ConfigureAwait(false);
                requestMessage.Content = new StringContent(json, Encoding.UTF8, Constants.MEDIA_TYPE);
                requestMessage.RequestBodyJson = json;
            }
        }

        private void SetRequestMessageHeaders(ExtendedHttpRequestMessage requestMessage)
        {
            if (_useAPIVersionHeader)
                requestMessage.Headers.Add(Constants.APIVersionHeaderKey, $"{_client.Configuration.ApiVersion}");

            if (_useAPIClientIdHeader)
                requestMessage.Headers.Add(Constants.APIClientIdHeaderKey, _client.ClientId);

            AuthorizationRequirement authorizationRequirement = _request.AuthorizationRequirement;

            if (authorizationRequirement != AuthorizationRequirement.NotRequired)
            {
                if (!_client.Authentication.IsAuthorized)
                {
                    switch (authorizationRequirement)
                    {
                        case AuthorizationRequirement.Optional:
                            if (_client.Configuration.ForceAuthorization)
                                throw new TraktAuthorizationException("authorization is optional for this request, but forced and the current authorization parameters are invalid");

                            break;
                        case AuthorizationRequirement.Required:
                            throw new TraktAuthorizationException("authorization is required for this request, but the current authorization parameters are invalid");
                    }
                }

                if (authorizationRequirement == AuthorizationRequirement.Required || (authorizationRequirement == AuthorizationRequirement.Optional && _client.Configuration.ForceAuthorization))
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_SCHEME, _client.Authentication.Authorization.AccessToken);
            }
        }
    }
}
