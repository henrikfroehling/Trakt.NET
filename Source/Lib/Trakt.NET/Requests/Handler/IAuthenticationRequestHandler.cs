namespace TraktNet.Requests.Handler
{
    using Authentication;
    using Objects.Authentication;
    using Responses;
    using System.Threading;
    using System.Threading.Tasks;
    using Utils;

    internal interface IAuthenticationRequestHandler
    {
        string CreateAuthorizationUrl(string clientId, string redirectUri, string state = null);

        string CreateAuthorizationUrlWithDefaultState(string clientId, string redirectUri);

        Task<Pair<bool, TraktResponse<ITraktAuthorization>>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(bool autoRefresh = false, CancellationToken cancellationToken = default);

        Task<Pair<bool, TraktResponse<ITraktAuthorization>>> CheckIfAuthorizationIsExpiredOrWasRevokedAsync(ITraktAuthorization authorization, bool autoRefresh = false, CancellationToken cancellationToken = default);

        Task<bool> CheckIfAccessTokenWasRevokedOrIsNotValidAsync(string accessToken, CancellationToken cancellationToken = default);

        Task<TraktResponse<ITraktDevice>> GetDeviceAsync(DeviceRequest request, CancellationToken cancellationToken = default);

        Task<TraktResponse<ITraktAuthorization>> GetAuthorizationAsync(AuthorizationRequest request, CancellationToken cancellationToken = default);

        Task<TraktResponse<ITraktAuthorization>> PollForAuthorizationAsync(AuthorizationPollRequest request, CancellationToken cancellationToken = default);

        Task<TraktResponse<ITraktAuthorization>> RefreshAuthorizationAsync(AuthorizationRefreshRequest request, CancellationToken cancellationToken = default);

        Task<TraktNoContentResponse> RevokeAuthorizationAsync(AuthorizationRevokeRequest request, string clientId, CancellationToken cancellationToken = default);
    }
}
