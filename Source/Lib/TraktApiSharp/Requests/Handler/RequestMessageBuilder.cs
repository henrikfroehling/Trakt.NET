namespace TraktApiSharp.Requests.Handler
{
    using Base;
    using Exceptions;
    using Interfaces;
    using Interfaces.Base;
    using System;
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using UriTemplates;

    internal class RequestMessageBuilder
    {
        private const string AUTHENTICATION_SCHEME = "Bearer";
        private const string SEASON_KEY = "season";
        private const string EPISODE_KEY = "episode";

        private IRequest _request;
        private IRequestBody _requestBody;
        private readonly TraktClient _client;

        internal RequestMessageBuilder(TraktClient client) => _client = client ?? throw new ArgumentNullException(nameof(client));

        internal RequestMessageBuilder(IRequest request, TraktClient client) : this(client) => _request = request;

        internal RequestMessageBuilder WithRequestBody(IRequestBody requestBody)
        {
            _requestBody = requestBody;
            return this;
        }

        internal RequestMessageBuilder Reset(IRequest request)
        {
            _request = request;
            _requestBody = null;
            return this;
        }

        internal ExtendedHttpRequestMessage Build()
        {
            ExtendedHttpRequestMessage requestMessage = CreateRequestMessage();
            AddRequestBodyContent(requestMessage);
            SetRequestMessageHeadersForAuthorization(requestMessage);
            return requestMessage;
        }

        private ExtendedHttpRequestMessage CreateRequestMessage()
        {
            if (_request == null)
                throw new ArgumentNullException(nameof(_request));

            IDictionary<string, object> requestUriParameters = null;
            string url = BuildUrl(requestUriParameters);

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

        private string BuildUrl(IDictionary<string, object> requestUriParameters)
        {
            var uriTemplate = new UriTemplate(_request.UriTemplate);
            requestUriParameters = _request.GetUriPathParameters();

            foreach (KeyValuePair<string, object> parameter in requestUriParameters)
                uriTemplate.AddParameterFromKeyValuePair(parameter.Key, parameter.Value);

            string url = uriTemplate.Resolve();
            return _client.Configuration.BaseUrl + url;
        }

        private void AddRequestBodyContent(ExtendedHttpRequestMessage requestMessage)
        {
            if (_requestBody != null)
            {
                requestMessage.Content = _requestBody.ToHttpContent();
                requestMessage.RequestBodyJson = _requestBody.HttpContentAsString;
            }
        }

        private void SetRequestMessageHeadersForAuthorization(ExtendedHttpRequestMessage requestMessage)
        {
            AuthorizationRequirement authorizationRequirement = _request.AuthorizationRequirement;

            if (authorizationRequirement == AuthorizationRequirement.Required)
            {
                if (!_client.Authentication.IsAuthorized)
                    throw new TraktAuthorizationException("authorization is required for this request, but the current authorization parameters are invalid");
            }
            else  if (authorizationRequirement == AuthorizationRequirement.Optional && _client.Configuration.ForceAuthorization)
            {
                if (!_client.Authentication.IsAuthorized)
                    throw new TraktAuthorizationException("authorization is optional for this request, but forced and the current authorization parameters are invalid");
            }

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_SCHEME, _client.Authentication.Authorization.AccessToken);
        }
    }
}
