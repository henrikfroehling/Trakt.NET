namespace TraktNet.Requests.Handler
{
    using Base;
    using Core;
    using Exceptions;
    using Interfaces;
    using Interfaces.Base;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.OAuth;

    internal class RequestMessageBuilder
    {
        private const string AUTHENTICATION_SCHEME = "Bearer";
        private const string SEASON_KEY = "season";
        private const string EPISODE_KEY = "episode";

        private readonly string _clientId;
        private readonly int _apiVersion;
        private readonly string _baseUrl;
        private readonly string _accessToken;
        private readonly bool _isAuthorized;
        private bool _forceAuthorization;

        internal bool UseAPIVersionHeader { get; set; } = true;

        internal bool UseAPIClientIdHeader { get; set; } = true;

        internal IRequest Request { get; set; }

        internal IRequestBody RequestBody { get; set; }

        internal RequestMessageBuilder(string clientId, int apiVersion, string baseUrl, string accessToken, bool isAuthorized, bool forceAuthorization)
        {
            _clientId = clientId;
            _apiVersion = apiVersion;
            _baseUrl = baseUrl;
            _accessToken = accessToken;
            _isAuthorized = isAuthorized;
            _forceAuthorization = forceAuthorization;
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
            Debug.Assert(Request != null);
            string url = BuildUrl();

            var requestMessage = new ExtendedHttpRequestMessage(Request.Method, url)
            {
                Url = url
            };

            if (Request is IHasId)
            {
                var idRequest = Request as IHasId;

                requestMessage.ObjectId = idRequest?.Id;
                requestMessage.RequestObjectType = idRequest?.RequestObjectType;
            }

            IDictionary<string, object> requestUriParameters = Request.GetUriPathParameters();

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
            var requestUri = new RequestUri(Request.UriTemplate, Request.GetUriPathParameters());
            string url = requestUri.ResolveUrl();
            return _baseUrl + url;
        }

        private async Task AddRequestBodyContent(ExtendedHttpRequestMessage requestMessage, CancellationToken cancellationToken = default)
        {
            if (RequestBody != null)
            {
                string json = await RequestBody.ToJson(cancellationToken).ConfigureAwait(false);
                requestMessage.Content = new StringContent(json, Encoding.UTF8, Constants.MEDIA_TYPE);
                requestMessage.RequestBodyJson = json;
            }
        }

        private void SetRequestMessageHeaders(ExtendedHttpRequestMessage requestMessage)
        {
            if (UseAPIVersionHeader)
                requestMessage.Headers.Add(Constants.APIVersionHeaderKey, $"{_apiVersion}");

            if (UseAPIClientIdHeader)
                requestMessage.Headers.Add(Constants.APIClientIdHeaderKey, _clientId);

            AuthorizationRequirement authorizationRequirement = Request.AuthorizationRequirement;

            if (authorizationRequirement == AuthorizationRequirement.OptionalButMightBeRequired && !_forceAuthorization)
            {
                // Force authorization for user requests where the username is "me",
                // even if forced authorization is disabled.
                _forceAuthorization = Request is IHasUsername && (Request as IHasUsername).Username == "me";
            }

            if (authorizationRequirement != AuthorizationRequirement.NotRequired)
            {
                if (!_isAuthorized)
                {
                    switch (authorizationRequirement)
                    {
                        case AuthorizationRequirement.Optional:
                        case AuthorizationRequirement.OptionalButMightBeRequired:
                            if (_forceAuthorization)
                                throw new TraktAuthorizationException("authorization is optional for this request, but forced and the current authorization parameters are invalid");

                            break;
                        case AuthorizationRequirement.Required:
                            throw new TraktAuthorizationException("authorization is required for this request, but the current authorization parameters are invalid");
                    }
                }

                bool authorizationOptionalButRequired = _forceAuthorization &&
                    (authorizationRequirement == AuthorizationRequirement.Optional || authorizationRequirement == AuthorizationRequirement.OptionalButMightBeRequired);

                if (authorizationRequirement == AuthorizationRequirement.Required || authorizationOptionalButRequired)
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue(AUTHENTICATION_SCHEME, _accessToken);
            }
        }
    }
}
