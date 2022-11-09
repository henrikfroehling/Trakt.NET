using TraktNet;
using TraktNet.Objects.Authentication;

const string CLIENT_SECRET = "ENTER_CLIENT_SECRET_HERE";

var client = new TraktClient("ENTER_CLIENT_ID_HERE");

Console.WriteLine($"Client Id: {client.ClientId}");
Console.WriteLine($"Client Secret: {client.ClientSecret}\n");

Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");

Console.WriteLine("-------------------------------------------------------");

client.ClientSecret = CLIENT_SECRET;

Console.WriteLine($"Client Id: {client.ClientId}");
Console.WriteLine($"Client Secret: {client.ClientSecret}\n");

Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");

Console.WriteLine("-------------------------------------------------------");

client.Authorization = TraktAuthorization.CreateWith(DateTime.Now, 90 * 24 * 3600, "FakeAccessToken", "FakeRefreshToken");

Console.WriteLine($"Client Id: {client.ClientId}");
Console.WriteLine($"Client Secret: {client.ClientSecret}\n");

Console.WriteLine($"Access Token: {client.Authorization.AccessToken}");
Console.WriteLine($"Refresh Token: {client.Authorization.RefreshToken}\n");

Console.WriteLine($"Requests without Authorization possible: {client.IsValidForUseWithoutAuthorization}");
Console.WriteLine($"Authentication possible: {client.IsValidForAuthenticationProcess}");
Console.WriteLine($"Requests with Authorization possible: {client.IsValidForUseWithAuthorization}");

Console.WriteLine("-------------------------------------------------------");

Console.WriteLine($"API Version: {client.Configuration.ApiVersion}");
Console.WriteLine($"API Base Url (UseStagingUrl == false): {client.Configuration.BaseUrl}");
client.Configuration.UseSandboxEnvironment = true;
Console.WriteLine($"API Base Url (UseStagingUrl == true): {client.Configuration.BaseUrl}");

Console.ReadLine();
