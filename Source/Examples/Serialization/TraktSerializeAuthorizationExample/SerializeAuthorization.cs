using TraktNet;
using TraktNet.Objects.Authentication;
using TraktNet.Services;

var client = new TraktClient("ENTER_CLIENT_ID_HERE", "ENTER_CLIENT_SECRET_HERE");

ITraktAuthorization fakeAuthorization = TraktAuthorization.CreateWith(DateTime.Now, 90 * 24 * 3600, "FakeAccessToken", "FakeRefreshToken");
client.Authorization = fakeAuthorization;

Console.WriteLine("Fake Authorization:");
Console.WriteLine($"Created (UTC): {fakeAuthorization.CreatedAt}");
Console.WriteLine($"Access Scope: {fakeAuthorization.Scope.DisplayName}");
Console.WriteLine($"Refresh Possible: {fakeAuthorization.IsRefreshPossible}");
Console.WriteLine($"Valid: {fakeAuthorization.IsValid}");
Console.WriteLine($"Token Type: {fakeAuthorization.TokenType.DisplayName}");
Console.WriteLine($"Access Token: {fakeAuthorization.AccessToken}");
Console.WriteLine($"Refresh Token: {fakeAuthorization.RefreshToken}");
Console.WriteLine($"Token Expired: {fakeAuthorization.IsExpired}");
Console.WriteLine($"Expires in {fakeAuthorization.ExpiresInSeconds / 3600 / 24} days");

Console.WriteLine("-------------------------------------------------------------");

string fakeAuthorizationJson = await TraktSerializationService.SerializeAsync(fakeAuthorization).ConfigureAwait(false);

if (!string.IsNullOrEmpty(fakeAuthorizationJson))
{
    Console.WriteLine("Serialized Fake Authorization:");
    Console.WriteLine(fakeAuthorizationJson);

    Console.WriteLine("-------------------------------------------------------------");

    ITraktAuthorization deserializedFakeAuthorization = await TraktSerializationService.DeserializeAsync(fakeAuthorizationJson).ConfigureAwait(false);

    if (deserializedFakeAuthorization != null)
    {
        client.Authorization = deserializedFakeAuthorization;

        Console.WriteLine("Deserialized Fake Authorization:");
        Console.WriteLine($"Created (UTC): {deserializedFakeAuthorization.CreatedAt}");
        Console.WriteLine($"Access Scope: {deserializedFakeAuthorization.Scope.DisplayName}");
        Console.WriteLine($"Refresh Possible: {deserializedFakeAuthorization.IsRefreshPossible}");
        Console.WriteLine($"Valid: {deserializedFakeAuthorization.IsValid}");
        Console.WriteLine($"Token Type: {deserializedFakeAuthorization.TokenType.DisplayName}");
        Console.WriteLine($"Access Token: {deserializedFakeAuthorization.AccessToken}");
        Console.WriteLine($"Refresh Token: {deserializedFakeAuthorization.RefreshToken}");
        Console.WriteLine($"Token Expired: {deserializedFakeAuthorization.IsExpired}");
        Console.WriteLine($"Expires in {deserializedFakeAuthorization.ExpiresInSeconds / 3600 / 24} days");
    }
}

Console.ReadLine();
