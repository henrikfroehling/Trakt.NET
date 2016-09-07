namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    using Authentication;
    using System;
    using System.Threading.Tasks;

    public class TraktAuthenticationService
    {
        private TraktClient Client { get; }

        private TraktAuthenticationService()
        {
            Client = TraktServiceProvider.Instance.Client;
        }

        public static TraktAuthenticationService Instance { get; } = new TraktAuthenticationService();

        public async Task<DeviceInfo> CreateDeviceAsync()
        {
            if (!Client.IsValidForAuthenticationProcess)
                throw new InvalidOperationException("Trakt client not valid for authentication");

            var device = await Client.DeviceAuth.GenerateDeviceAsync();

            if (device != null && device.IsValid)
                return new DeviceInfo(true, device.VerificationUrl, device.UserCode);

            return new DeviceInfo(false, string.Empty, string.Empty);
        }

        public async Task<TraktAuthorization> GetAuthorizationAsync(bool deviceAuthentication, string code = null)
        {
            if (deviceAuthentication)
                return await GetDeviceAuthorizationAsync();
            else
                return await GetOAuthAuthorizationAsync(code);

            throw new InvalidOperationException("no authentication method specified");
        }

        public async Task<TraktAuthorization> GetDeviceAuthorizationAsync()
        {
            var device = Client.Authentication.Device;

            if (device == null || !device.IsValid || device.IsExpiredUnused)
                throw new InvalidOperationException("no device for authentication created");

            return await Client.DeviceAuth.PollForAuthorizationAsync();
        }

        public string GetOAuthAuthorizationUrl() => Client.OAuth.CreateAuthorizationUrl();

        public async Task<TraktAuthorization> GetOAuthAuthorizationAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentException("code not valid");

            return await Client.OAuth.GetAuthorizationAsync(code);
        }

        public async Task<TraktAuthorization> RefreshAuthorizationAsync() => await Client.Authentication.RefreshAuthorizationAsync();

        public async Task RevokeAuthorizationAsync()
        {
            await Client.Authentication.RevokeAuthorizationAsync();
        }
    }

    public struct DeviceInfo
    {
        public DeviceInfo(bool success, string url, string userCode)
        {
            Success = success;
            Url = url;
            UserCode = userCode;
        }

        public bool Success { get; }
        public string Url { get; }
        public string UserCode { get; }
    }
}
