namespace TraktDeviceAuthenticationExample
{
    using System;
    using System.Threading.Tasks;
    using TraktApiSharp;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Exceptions;

    class Program
    {
        private const string CLIENT_ID = "ENTER_CLIENT_ID_HERE";
        private const string CLIENT_SECRET = "ENTER_CLIENT_SECRET_HERE";

        private static TraktClient _client = null;

        static void Main(string[] args)
        {
            try
            {
                SetupClient();
                TryToDeviceAuthenticate().Wait();

                TraktAuthorization authorization = _client.Authorization;

                if (authorization == null || !authorization.IsValid)
                    throw new InvalidOperationException("Trakt Client not authenticated for requests, that require OAuth");
            }
            catch (TraktException ex)
            {
                Console.WriteLine("-------------- Trakt Exception --------------");
                Console.WriteLine($"Exception message: {ex.Message}");
                Console.WriteLine($"Status code: {ex.StatusCode}");
                Console.WriteLine($"Request URL: {ex.RequestUrl}");
                Console.WriteLine($"Request message: {ex.RequestBody}");
                Console.WriteLine($"Request response: {ex.Response}");
                Console.WriteLine($"Server Reason Phrase: {ex.ServerReasonPhrase}");
                Console.WriteLine("---------------------------------------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine("-------------- Exception --------------");
                Console.WriteLine($"Exception message: {ex.Message}");
                Console.WriteLine("---------------------------------------");
            }

            Console.ReadLine();
        }

        static void SetupClient()
        {
            if (_client == null)
            {
                _client = new TraktClient(CLIENT_ID, CLIENT_SECRET);

                if (!_client.IsValidForAuthenticationProcess)
                    throw new InvalidOperationException("Trakt Client not valid for authentication");
            }
        }

        static async Task TryToDeviceAuthenticate()
        {
            TraktDevice device = await _client.DeviceAuth.GenerateDeviceAsync();

            if (device != null && device.IsValid)
            {
                Console.WriteLine("-------------- Device created successfully --------------");
                Console.WriteLine($"Device Created (UTC): {device.Created}");
                Console.WriteLine($"Device Code: {device.DeviceCode}");
                Console.WriteLine($"Device expires in {device.ExpiresInSeconds} seconds");
                Console.WriteLine($"Device Interval: {device.IntervalInSeconds} seconds");
                Console.WriteLine($"Device Expired Unused: {device.IsExpiredUnused}");
                Console.WriteLine($"Device Valid: {device.IsValid}");
                Console.WriteLine("-------------------------------------------------------");

                Console.WriteLine("You have to authenticate this application.");
                Console.WriteLine($"Please visit the following webpage: {device.VerificationUrl}");
                Console.WriteLine($"Sign in or sign up on that webpage and enter the following code: {device.UserCode}");

                TraktAuthorization authorization = await _client.DeviceAuth.PollForAuthorizationAsync();

                if (authorization != null && authorization.IsValid)
                {
                    Console.WriteLine("-------------- Authentication successful --------------");
                    Console.WriteLine($"Created (UTC): {authorization.Created}");
                    Console.WriteLine($"Access Scope: {authorization.AccessScope.DisplayName}");
                    Console.WriteLine($"Refresh Possible: {authorization.IsRefreshPossible}");
                    Console.WriteLine($"Valid: {authorization.IsValid}");
                    Console.WriteLine($"Token Type: {authorization.TokenType.DisplayName}");
                    Console.WriteLine($"Access Token: {authorization.AccessToken}");
                    Console.WriteLine($"Refresh Token: {authorization.RefreshToken}");
                    Console.WriteLine($"Token Expired: {authorization.IsExpired}");
                    Console.WriteLine($"Expires in {authorization.ExpiresIn / 3600 / 24} days");
                    Console.WriteLine("-------------------------------------------------------");
                }
            }
        }
    }
}
