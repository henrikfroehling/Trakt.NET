namespace Trakt.NET.Tests.Utility
{
    using System;
    using TraktNet.Objects.Authentication;

    internal static class TestConstants
    {
        internal static readonly DateTime CREATED_AT = DateTime.UtcNow;
        internal const string TRAKT_CLIENT_ID = "traktClientId";
        internal const string TRAKT_CLIENT_SECRET = "traktClientSecret";
        internal const string DEFAULT_REDIRECT_URI = "urn:ietf:wg:oauth:2.0:oob";
        internal const string MOCK_ACCESS_TOKEN = "mockAccessToken";
        internal const string MOCK_REFRESH_TOKEN = "mockRefreshToken";

        internal static readonly TraktAuthorization MOCK_AUTHORIZATION =
            new TraktAuthorization
            {
                CreatedAtTimestamp = TestUtility.CalculateTimestamp(CREATED_AT),
                AccessToken = MOCK_ACCESS_TOKEN,
                ExpiresInSeconds = 3600
            };
    }
}
