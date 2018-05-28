namespace TraktApiSharp.Modules
{
    using Objects.Authentication;
    using Objects.Authentication.Implementations;
    using Requests.Authentication;
    using Requests.Handler;
    using Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    public class TraktAuthenticationModule : ATraktModule
    {
        private const string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";

        private ITraktAuthorization _authorization;
        private ITraktDevice _device;

        internal TraktAuthenticationModule(TraktClient client) : base(client)
        {
        }

        public string OAuthAuthorizationCode { get; set; }

        public ITraktAuthorization Authorization
        {
            get { return _authorization = _authorization ?? new TraktAuthorization(); }
            set { _authorization = value; }
        }

        public ITraktDevice Device
        {
            get { return _device = _device ?? new TraktDevice(); }
            set { _device = value; }
        }

        public string AntiForgeryToken { get; } = Guid.NewGuid().ToString();

        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string RedirectUri { get; set; } = DEFAULT_REDIRECT_URI;

        public bool IsAuthorized => Authorization?.IsExpired == false;

        public Task<Pair<bool, TraktResponse<ITraktAuthorization>>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(bool autoRefresh = false, CancellationToken cancellationToken = default)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(autoRefresh, cancellationToken);
        }

        public Task<Pair<bool, TraktResponse<ITraktAuthorization>>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(ITraktAuthorization authorization, bool autoRefresh = false, CancellationToken cancellationToken = default)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CheckIfAuthorizationIsExpiredOrWasRevokedAsync(authorization, autoRefresh, cancellationToken);
        }

        public Task<bool> CheckIfAccessTokenWasRevokedOrIsNotValidAsync(string accessToken, CancellationToken cancellationToken = default)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CheckIfAccessTokenWasRevokedOrIsNotValidAsync(accessToken, cancellationToken);
        }

        public string CreateAuthorizationUrl() => CreateAuthorizationUrl(ClientId);

        public string CreateAuthorizationUrl(string clientId) => CreateAuthorizationUrl(clientId, RedirectUri);

        public string CreateAuthorizationUrl(string clientId, string redirectUri)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CreateAuthorizationUrl(clientId, redirectUri);
        }

        public string CreateAuthorizationUrl(string clientId, string redirectUri, string state)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CreateAuthorizationUrl(clientId, redirectUri, state);
        }

        public string CreateAuthorizationUrlWithDefaultState() => CreateAuthorizationUrlWithDefaultState(ClientId);

        public string CreateAuthorizationUrlWithDefaultState(string clientId) => CreateAuthorizationUrlWithDefaultState(clientId, RedirectUri);

        public string CreateAuthorizationUrlWithDefaultState(string clientId, string redirectUri)
        {
            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.CreateAuthorizationUrlWithDefaultState(clientId, redirectUri);
        }

        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(OAuthAuthorizationCode, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(string code, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, ClientId, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(string code, string clientId, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, clientId, ClientSecret, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(string code, string clientId, string clientSecret, CancellationToken cancellationToken = default)
            => GetAuthorizationAsync(code, clientId, clientSecret, RedirectUri, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(string code, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
        {
            var request = new AuthorizationRequest
            {
                RequestBody = new AuthorizationRequestBody
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Code = code,
                    RedirectUri = redirectUri
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.GetAuthorizationAsync(request, cancellationToken);
        }

        public Task<TraktResponse<ITraktDevice>> GenerateDeviceAsync(CancellationToken cancellationToken = default)
            => GenerateDeviceAsync(ClientId, cancellationToken);

        public Task<TraktResponse<ITraktDevice>> GenerateDeviceAsync(string clientId, CancellationToken cancellationToken = default)
        {
            var request = new DeviceRequest
            {
                RequestBody = new DeviceRequestBody
                {
                    ClientId = clientId
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.GetDeviceAsync(request, cancellationToken);
        }

        public Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(Device, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(ITraktDevice device, CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(device, ClientId, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(ITraktDevice device, string clientId, CancellationToken cancellationToken = default)
            => PollForAuthorizationAsync(device, clientId, ClientSecret, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(ITraktDevice device, string clientId, string clientSecret, CancellationToken cancellationToken = default)
        {
            var request = new AuthorizationPollRequest
            {
                RequestBody = new AuthorizationPollRequestBody
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Device = device
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.PollForAuthorizationAsync(request, cancellationToken);
        }

        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(Authorization.RefreshToken, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, ClientId, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, clientId, ClientSecret, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, CancellationToken cancellationToken = default)
            => RefreshAuthorizationAsync(refreshToken, clientId, clientSecret, RedirectUri, cancellationToken);

        public Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(string refreshToken, string clientId, string clientSecret, string redirectUri, CancellationToken cancellationToken = default)
        {
            var request = new AuthorizationRefreshRequest
            {
                RequestBody = new AuthorizationRefreshRequestBody
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    RedirectUri = redirectUri,
                    RefreshToken = refreshToken
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.RefreshAuthorizationAsync(request, cancellationToken);
        }

        public Task<TraktNoContentResponse> RevokeAuthorizationAsync(CancellationToken cancellationToken = default)
            => RevokeAuthorizationAsync(Authorization.AccessToken, cancellationToken);

        public Task<TraktNoContentResponse> RevokeAuthorizationAsync(string accessToken, CancellationToken cancellationToken = default)
            => RevokeAuthorizationAsync(accessToken, ClientId, cancellationToken);

        public Task<TraktNoContentResponse> RevokeAuthorizationAsync(string accessToken, string clientId, CancellationToken cancellationToken = default)
        {
            var request = new AuthorizationRevokeRequest
            {
                RequestBody = new AuthorizationRevokeRequestBody
                {
                    AccessToken = accessToken
                }
            };

            var requestHandler = new AuthenticationRequestHandler(Client);
            return requestHandler.RevokeAuthorizationAsync(request, clientId, cancellationToken);
        }
    }
}
