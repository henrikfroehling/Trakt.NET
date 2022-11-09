using Trakt.Net.Examples.Utility;
using TraktNet;
using TraktNet.Exceptions;
using TraktNet.Objects.Authentication;
using TraktNet.Responses;

var client = new TraktClient("ENTER_CLIENT_ID_HERE", "ENTER_CLIENT_SECRET_HERE");

try
{
    if (!client.IsValidForAuthenticationProcess)
        throw new InvalidOperationException("Trakt Client not valid for authentication");

    await TryToDeviceAuthenticateAsync().ConfigureAwait(false);

    ITraktAuthorization authorization = client.Authorization;

    if (authorization?.IsValid != true)
        throw new InvalidOperationException("Trakt Client not authenticated for requests, that require OAuth");

    Console.Write("\nDo you want to refresh the current authorization? [y/n]: ");
    string yesNo = Console.ReadLine();

    if (yesNo.Equals("y"))
        await TryToRefreshAuthorizationAsync().ConfigureAwait(false);

    Console.Write("\nDo you want to revoke your authorization? [y/n]: ");
    yesNo = Console.ReadLine();

    if (yesNo.Equals("y"))
        await TryToRevokeAuthorizationAsync().ConfigureAwait(false);
}
catch (TraktException ex)
{
    ExamplesUtility.PrintTraktException(ex);
}
catch (Exception ex)
{
    ExamplesUtility.PrintException(ex);
}

Console.ReadLine();

async Task TryToDeviceAuthenticateAsync()
{
    TraktResponse<ITraktDevice> deviceResponse = await client.Authentication.GenerateDeviceAsync().ConfigureAwait(false);

    if (deviceResponse)
    {
        ITraktDevice device = deviceResponse.Value;

        if (device?.IsValid == true)
        {
            Console.WriteLine("-------------- Device created successfully --------------");
            Console.WriteLine($"Device Created (UTC): {device.CreatedAt}");
            Console.WriteLine($"Device Code: {device.DeviceCode}");
            Console.WriteLine($"Device expires in {device.ExpiresInSeconds} seconds");
            Console.WriteLine($"Device Interval: {device.IntervalInSeconds} seconds");
            Console.WriteLine($"Device Expired Unused: {device.IsExpiredUnused}");
            Console.WriteLine($"Device Valid: {device.IsValid}");
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("You have to authenticate this application.");
            Console.WriteLine($"Please visit the following webpage: {device.VerificationUrl}");
            Console.WriteLine($"Sign in or sign up on that webpage and enter the following code: {device.UserCode}");

            TraktResponse<ITraktAuthorization> authorizationResponse = await client.Authentication.PollForAuthorizationAsync().ConfigureAwait(false);

            if (authorizationResponse)
            {
                ITraktAuthorization authorization = authorizationResponse.Value;

                if (authorization?.IsValid == true)
                {
                    Console.WriteLine("-------------- Authentication successful --------------");
                    WriteAuthorizationInformation(authorization);
                    Console.WriteLine("-------------------------------------------------------");
                }
                else
                    Console.WriteLine("-------------- Authentication failed --------------");
            }
        }
    }
}

async Task TryToRefreshAuthorizationAsync()
{
    TraktResponse<ITraktAuthorization> newAuthorizationResponse = await client.Authentication.RefreshAuthorizationAsync().ConfigureAwait(false);

    if (newAuthorizationResponse)
    {
        ITraktAuthorization newAuthorization = newAuthorizationResponse.Value;

        if (newAuthorization?.IsValid == true)
        {
            Console.WriteLine("-------------- Authorization refreshed successfully --------------");
            WriteAuthorizationInformation(newAuthorization);
            Console.WriteLine("-------------------------------------------------------");
        }
    }
}

async Task TryToRevokeAuthorizationAsync()
{
    TraktNoContentResponse response = await client.Authentication.RevokeAuthorizationAsync().ConfigureAwait(false);

    if (response)
    {
        // If no exception was thrown, revoking was successfull
        Console.WriteLine("-----------------------------------");
        Console.WriteLine("Authorization revoked successfully");
        Console.WriteLine("-----------------------------------");
    }
}

void WriteAuthorizationInformation(ITraktAuthorization authorization)
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
