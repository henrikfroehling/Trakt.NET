namespace TraktSerializeAuthorizationExample
{
    using System;
    using System.Threading.Tasks;
    using TraktNet;
    using TraktNet.Objects.Authentication;
    using TraktNet.Services;

    internal static class SerializeAuthorization
    {
        private const string CLIENT_ID = "FAKE_CLIENT_ID";
        private const string CLIENT_SECRET = "FAKE_CLIENT_SECRET";

        private static async Task Main()
        {
            var client = new TraktClient(CLIENT_ID, CLIENT_SECRET);

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
        }
    }
}
