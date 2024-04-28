using Trakt.NET.Examples.Helper;
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Authentication;
using TraktNet.Responses;

namespace Trakt.NET.Examples.Authentication;

internal static class AuthenticationOAuthExample
{
    internal static async Task RunAsync()
    {
        Console.WriteLine("Trakt.NET - OAuth Authentication Example");
        Console.WriteLine();

        Console.WriteLine("Please enter your Trakt Client-ID:");
        string? clientID = Console.ReadLine();

        Console.WriteLine("Please enter your Trakt Client-Secret:");
        string? clientSecret = Console.ReadLine();

        var client = new TraktClient(clientID, clientSecret);

        try
        {
            string authorizationUrl = client.Authentication.CreateAuthorizationUrl();

            if (!string.IsNullOrEmpty(authorizationUrl))
            {
                Console.WriteLine("You have to authenticate this application.");
                Console.WriteLine("Please visit the following webpage:");
                Console.WriteLine($"{authorizationUrl}\n");

                Console.WriteLine("Enter the PIN code from Trakt.tv:");
                string? code = Console.ReadLine();

                if (!string.IsNullOrEmpty(code))
                {
                    TraktResponse<ITraktAuthorization> authorizationResponse = await client.Authentication.GetAuthorizationAsync(code);

                    // NOTE: We do not need to explicitly set the authorization in the client.
                    // This is not necessary, since it's automatically set.
                    // client.Authorization = authorizationResponse.Value;

                    ITraktAuthorization authorization = authorizationResponse.Value;

                    // or
                    // ITraktAuthorization authorization = client.Authorization;

                    if (authorization.IsValid)
                    {
                        Console.WriteLine("-------------- Authentication successful --------------");
                        authorization.WriteAuthorizationInformation();
                        Console.WriteLine("-------------------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("-------------- Authentication failed --------------");
                    }

                    Console.WriteLine("Do you want to refresh the current authorization? [y/n]:");
                    string? yesNo = Console.ReadLine();

                    if (yesNo != null && yesNo.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        TraktResponse<ITraktAuthorization> newAuthorizationResponse = await client.Authentication.RefreshAuthorizationAsync();

                        ITraktAuthorization newAuthorization = newAuthorizationResponse.Value;

                        if (newAuthorization.IsValid)
                        {
                            Console.WriteLine("-------------- Authorization refreshed successfully --------------");
                            newAuthorization.WriteAuthorizationInformation();
                            Console.WriteLine("-------------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("-------------- Refreshing Authorization failed --------------");
                        }
                    }

                    Console.WriteLine("Do you want to revoke your authorization? [y/n]:");
                    yesNo = Console.ReadLine();

                    if (yesNo != null && yesNo.Equals("y", StringComparison.OrdinalIgnoreCase))
                    {
                        TraktNoContentResponse response = await client.Authentication.RevokeAuthorizationAsync();

                        // If no exception was thrown, revoking was successfull
                        Console.WriteLine("-----------------------------------");
                        Console.WriteLine("Authorization revoked successfully");
                        Console.WriteLine("-----------------------------------");
                    }
                }
            }
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

        Console.WriteLine();
    }
}
