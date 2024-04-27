using TraktNet.Objects.Authentication;
using TraktNet.Services;

namespace Trakt.NET.Examples.Serialization;

internal static class SerializationExample
{
    internal static async Task RunAsync()
    {
        ITraktAuthorization fakeAuthorization = TraktAuthorization.CreateWith(DateTime.Now, 90 * 24 * 3600, "FakeAccessToken", "FakeRefreshToken");

        string fakeAuthorizationJson = await TraktSerializationService.SerializeAsync(fakeAuthorization);

        Console.WriteLine("Serialized Fake Authorization:");
        Console.WriteLine(fakeAuthorizationJson);

        ITraktAuthorization deserializedFakeAuthorization = await TraktSerializationService.DeserializeAsync(fakeAuthorizationJson);

        if (deserializedFakeAuthorization != null)
        {
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
}
