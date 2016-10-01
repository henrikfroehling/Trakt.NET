namespace TraktDeviceAuthenticationExample
{
    using System;
    using System.Threading.Tasks;
    using TraktApiSharp;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Exceptions;

    class DeviceAuthentication
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

                Console.Write("\nDo you want to refresh the current authorization? [y/n]: ");
                string yesNo = Console.ReadLine();

                if (yesNo.Equals("y"))
                    TryToRefreshAuthorization().Wait();

                Console.Write("\nDo you want to revoke your authorization? [y/n]: ");
                yesNo = Console.ReadLine();

                if (yesNo.Equals("y"))
                    TryToRevokeAuthorization().Wait();
            }
            catch (Exception ex)
            {
                PrintException(ex);
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
            try
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
                        WriteAuthorizationInformation(authorization);
                        Console.WriteLine("-------------------------------------------------------");
                    }
                }
            }
            catch (TraktException ex)
            {
                PrintTraktException(ex);
            }
            catch (Exception ex)
            {
                PrintException(ex);
            }
        }

        static async Task TryToRefreshAuthorization()
        {
            try
            {
                TraktAuthorization newAuthorization = await _client.DeviceAuth.RefreshAuthorizationAsync();

                if (newAuthorization != null && newAuthorization.IsValid)
                {
                    Console.WriteLine("-------------- Authorization refreshed successfully --------------");
                    WriteAuthorizationInformation(newAuthorization);
                    Console.WriteLine("-------------------------------------------------------");
                }
            }
            catch (TraktException ex)
            {
                PrintTraktException(ex);
            }
            catch (Exception ex)
            {
                PrintException(ex);
            }
        }

        static async Task TryToRevokeAuthorization()
        {
            try
            {
                await _client.DeviceAuth.RevokeAuthorizationAsync();
                // If no exception was thrown, revoking was successfull
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Authorization revoked successfully");
                Console.WriteLine("-----------------------------------");
            }
            catch (TraktException ex)
            {
                PrintTraktException(ex);
            }
            catch (Exception ex)
            {
                PrintException(ex);
            }
        }

        static void WriteAuthorizationInformation(TraktAuthorization authorization)
        {
            Console.WriteLine($"Created (UTC): {authorization.Created}");
            Console.WriteLine($"Access Scope: {authorization.AccessScope.DisplayName}");
            Console.WriteLine($"Refresh Possible: {authorization.IsRefreshPossible}");
            Console.WriteLine($"Valid: {authorization.IsValid}");
            Console.WriteLine($"Token Type: {authorization.TokenType.DisplayName}");
            Console.WriteLine($"Access Token: {authorization.AccessToken}");
            Console.WriteLine($"Refresh Token: {authorization.RefreshToken}");
            Console.WriteLine($"Token Expired: {authorization.IsExpired}");

            var created = authorization.Created;
            var expirationDate = created.AddSeconds(authorization.ExpiresInSeconds);
            var difference = expirationDate - DateTime.UtcNow;

            var days = difference.Days > 0 ? difference.Days : 0;
            var hours = difference.Hours > 0 ? difference.Hours : 0;
            var minutes = difference.Minutes > 0 ? difference.Minutes : 0;

            Console.WriteLine($"Expires in {days} Days, {hours} Hours, {minutes} Minutes");
        }

        static void PrintTraktException(TraktException ex)
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

        static void PrintException(Exception ex)
        {
            Console.WriteLine("-------------- Exception --------------");
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine("---------------------------------------");
        }
    }
}
