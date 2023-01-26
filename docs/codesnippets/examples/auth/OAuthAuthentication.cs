using TraktNet.Exceptions;
using TraktNet.Objects.Authentication;
using TraktNet.Responses;

// Helper method for writing authorization information
void WriteAuthorizationInformation(ITraktAuthorization authorization)
{
    Console.WriteLine($"Created (UTC): {authorization.CreatedAt}");
    Console.WriteLine($"Access Scope: {authorization.Scope.DisplayName}");
    Console.WriteLine($"Refresh Possible: {authorization.IsRefreshPossible}");
    Console.WriteLine($"Valid: {authorization.IsValid}");
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

try
{
    string authorizationUrl = client.Authentication.CreateAuthorizationUrl();

    if (!string.IsNullOrEmpty(authorizationUrl))
    {
        Console.WriteLine("You have to authenticate this application.");
        Console.WriteLine("Please visit the following webpage:");
        Console.WriteLine($"{authorizationUrl}\n");

        Console.WriteLine("Enter the PIN code from Trakt.tv:");
        string code = Console.ReadLine();

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
                WriteAuthorizationInformation(authorization);
                Console.WriteLine("-------------------------------------------------------");
            }
            else
                Console.WriteLine("-------------- Authentication failed --------------");

            Console.Writeline("Do you want to refresh the current authorization? [y/n]:");
            string yesNo = Console.ReadLine();

            if (yesNo.Equals("y"))
            {
                TraktResponse<ITraktAuthorization> newAuthorizationResponse = await client.Authentication.RefreshAuthorizationAsync();
    
                ITraktAuthorization newAuthorization = newAuthorizationResponse.Value;
    
                if (newAuthorization.IsValid)
                {
                    Console.WriteLine("-------------- Authorization refreshed successfully --------------");
                    WriteAuthorizationInformation(newAuthorization);
                    Console.WriteLine("-------------------------------------------------------");
                }
                else
                    Console.WriteLine("-------------- Refreshing Authorization failed --------------");
            }
    
            Console.WriteLine("Do you want to revoke your authorization? [y/n]:");
            yesNo = Console.ReadLine();
    
            if (yesNo.Equals("y"))
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