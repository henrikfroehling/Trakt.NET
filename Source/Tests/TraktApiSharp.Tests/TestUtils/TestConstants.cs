namespace TraktApiSharp.Tests.TestUtils
{
    using System;
    using TraktApiSharp.Objects.Authentication.Implementations;

    internal static class TestConstants
    {
        private static readonly DateTime CREATED_AT = DateTime.UtcNow;

        internal const string TRAKT_CLIENT_ID = "traktClientId";
        internal const string TRAKT_CLIENT_SECRET = "traktClientSecret";

        internal static readonly TraktAuthorization MOCK_AUTHORIZATION =
            new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(CREATED_AT),
                AccessToken = "mock_access_token",
                ExpiresInSeconds = 3600
            };
    }
}
