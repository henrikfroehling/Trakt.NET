### Serialize Authorization

This example shows how we can serialize a given authorization as JSON data and deserialize the JSON data back to an authorization.

For this example we simply create a fake authorization.

```csharp
using TraktNet.Objects.Authentication;

ITraktAuthorization fakeAuthorization = TraktAuthorization.CreateWith(DateTime.Now, 90 * 24 * 3600, "FakeAccessToken", "FakeRefreshToken");
```

We use the [`TraktSerializationService`](xref:TraktNet.Services.TraktSerializationService) to serialize the previously created authorization as JSON data.

```csharp
using TraktNet.Services;

string fakeAuthorizationJson = await TraktSerializationService.SerializeAsync(fakeAuthorization);

Console.WriteLine("Serialized Fake Authorization:");
Console.WriteLine(fakeAuthorizationJson);
```

Then, we use the [`TraktSerializationService`](xref:TraktNet.Services.TraktSerializationService) to deserialize the JSON data back to an authorization object.

```csharp
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
```
