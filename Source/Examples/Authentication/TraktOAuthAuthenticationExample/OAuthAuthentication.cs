namespace TraktOAuthAuthenticationExample
{
    using System;
    using System.Threading.Tasks;
    using TraktNet;
    using TraktNet.Exceptions;
    using TraktNet.Objects.Authentication;
    using TraktNet.Responses;

    internal static class OAuthAuthentication
    {
        private const string CLIENT_ID = "ENTER_CLIENT_ID_HERE";
        private const string CLIENT_SECRET = "ENTER_CLIENT_SECRET_HERE";

        private static TraktClient _client = null;

        private static async Task Main()
        {
            try
            {
                SetupClient();
                await TryToOAuthAuthenticate().ConfigureAwait(false);

                ITraktAuthorization authorization = _client.Authorization;

                if (authorization?.IsValid != true)
                    throw new InvalidOperationException("Trakt Client not authenticated for requests, that require OAuth");

                Console.Write("\nDo you want to refresh the current authorization? [y/n]: ");
                string yesNo = Console.ReadLine();

                if (yesNo.Equals("y"))
                    await TryToRefreshAuthorization().ConfigureAwait(false);

                Console.Write("\nDo you want to revoke your authorization? [y/n]: ");
                yesNo = Console.ReadLine();

                if (yesNo.Equals("y"))
                    await TryToRevokeAuthorization().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                PrintException(ex);
            }

            Console.ReadLine();
        }

        private static void SetupClient()
        {
            if (_client == null)
            {
                _client = new TraktClient(CLIENT_ID, CLIENT_SECRET);

                if (!_client.IsValidForAuthenticationProcess)
                    throw new InvalidOperationException("Trakt Client not valid for authentication");
            }
        }

        private static async Task TryToOAuthAuthenticate()
        {
            try
            {
                string authorizationUrl = _client.Authentication.CreateAuthorizationUrl();

                if (!string.IsNullOrEmpty(authorizationUrl))
                {
                    Console.WriteLine("You have to authenticate this application.");
                    Console.WriteLine("Please visit the following webpage:");
                    Console.WriteLine($"{authorizationUrl}\n");
                    Console.Write("Enter the PIN code from Trakt.tv: ");

                    string code = Console.ReadLine();

                    if (!string.IsNullOrEmpty(code))
                    {
                        TraktResponse<ITraktAuthorization> authorizationResponse = await _client.Authentication.GetAuthorizationAsync(code).ConfigureAwait(false);

                        if (authorizationResponse)
                        {
                            ITraktAuthorization authorization = authorizationResponse.Value;

                            if (authorization?.IsValid == true)
                            {
                                Console.WriteLine("-------------- Authentication successful --------------");
                                WriteAuthorizationInformation(authorization);
                                Console.WriteLine("-------------------------------------------------------");
                            }
                        }
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

        private static async Task TryToRefreshAuthorization()
        {
            try
            {
                TraktResponse<ITraktAuthorization> newAuthorizationResponse = await _client.Authentication.RefreshAuthorizationAsync().ConfigureAwait(false);

                if (newAuthorizationResponse)
                {
                    ITraktAuthorization newAuthorization = newAuthorizationResponse.Value;

                    if (newAuthorization?.IsValid == true)
                    {
                        Console.WriteLine("-------------- Authorization refreshed successfully --------------");
                        WriteAuthorizationInformation(newAuthorization);
                        Console.WriteLine("-------------------------------------------------------");
                    }
                    else
                        Console.WriteLine("-------------- Authentication failed --------------");
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

        private static async Task TryToRevokeAuthorization()
        {
            try
            {
                TraktNoContentResponse response = await _client.Authentication.RevokeAuthorizationAsync().ConfigureAwait(false);

                if (response)
                {
                    // If no exception was thrown, revoking was successfull
                    Console.WriteLine("-----------------------------------");
                    Console.WriteLine("Authorization revoked successfully");
                    Console.WriteLine("-----------------------------------");
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

        private static void WriteAuthorizationInformation(ITraktAuthorization authorization)
        {
            Console.WriteLine($"Created (UTC): {authorization.CreatedAt}");
            Console.WriteLine($"Access Scope: {authorization.Scope.DisplayName}");
            Console.WriteLine($"Refresh Possible: {authorization.IsRefreshPossible}");
            Console.WriteLine($"Valid: {authorization.IsValid}");
            Console.WriteLine($"Token Type: {authorization.TokenType.DisplayName}");
            Console.WriteLine($"Access Token: {authorization.AccessToken}");
            Console.WriteLine($"Refresh Token: {authorization.RefreshToken}");
            Console.WriteLine($"Token Expired: {authorization.IsExpired}");

            var created = authorization.CreatedAt;
            var expirationDate = created.AddSeconds(authorization.ExpiresInSeconds);
            var difference = expirationDate - DateTime.UtcNow;

            var days = difference.Days > 0 ? difference.Days : 0;
            var hours = difference.Hours > 0 ? difference.Hours : 0;
            var minutes = difference.Minutes > 0 ? difference.Minutes : 0;

            Console.WriteLine($"Expires in {days} Days, {hours} Hours, {minutes} Minutes");
        }

        private static void PrintTraktException(TraktException ex)
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

        private static void PrintException(Exception ex)
        {
            Console.WriteLine("-------------- Exception --------------");
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine("---------------------------------------");
        }
    }
}
