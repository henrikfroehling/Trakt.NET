namespace TraktNET.Json.Authentication
{
    public sealed class TraktAuthorizationTests
    {
        private const uint EXPIRES_IN_SECONDS = 7776000;
        private const string ACCESS_TOKEN = "accessToken";
        private const string REFRESH_TOKEN = "refreshToken";
        private readonly DateTime CreatedAt = new(2017, 2, 23, 22, 42, 21, DateTimeKind.Utc);

        [Fact]
        public void TestTraktAuthorizationConstructor()
        {
            var authorization = new TraktAuthorization();

            authorization.AccessToken.ShouldBeNull();
            authorization.RefreshToken.ShouldBeNull();
            authorization.ExpiresIn.ShouldBeNull();
            authorization.ExpiresInSeconds.ShouldBe(0U);
            authorization.CreatedAt.ShouldBeNull();
            authorization.CreatedAtTimestamp.ShouldBe(0UL);
            authorization.CreatedAtDateTime.ShouldBe(default);
            authorization.Scope.ShouldBeNull();
            authorization.TokenType.ShouldBeNull();
            authorization.IsExpired.ShouldBe(true);
            authorization.IsValid.ShouldBe(false);
            authorization.IsRefreshPossible.ShouldBe(false);
            authorization.IgnoreExpiration.ShouldBe(false);

            authorization.AsBearerToken().ShouldBe("Bearer: invalid access token");
        }

        [Fact]
        public async Task TestTraktAuthorizationFromJson()
        {
            TraktAuthorization? authorization = await TraktTestUtility.DeserializeJsonAsync<TraktAuthorization>("Authentication\\authorization.json");

            authorization.ShouldNotBeNull();

            authorization!.AccessToken.ShouldBe("dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781");
            authorization!.RefreshToken.ShouldBe("76ba4c5c75c96f6087f58a4de10be6c00b29ea1ddc3b2022ee2016d1363e3a7c");
            authorization!.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization!.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization!.CreatedAt.ShouldBe(1487889741UL);
            authorization!.CreatedAtTimestamp.ShouldBe(1487889741UL);
            authorization!.CreatedAtDateTime.ShouldBe(CreatedAt);
            authorization!.Scope.ShouldBe(TraktAccessScope.Public);
            authorization!.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization!.IsExpired.ShouldBe(true);
            authorization!.IsValid.ShouldBe(true);
            authorization!.IsRefreshPossible.ShouldBe(true);
            authorization!.IgnoreExpiration.ShouldBe(false);

            authorization!.AsBearerToken().ShouldBe("Bearer: dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781");
        }

        [Fact]
        public void TestTraktAuthorizationIsValid()
        {
            var authorization = new TraktAuthorization();

            authorization.IsValid.ShouldBe(false);

            authorization.AccessToken = string.Empty;
            authorization.IsValid.ShouldBe(false);

            authorization.AccessToken = "access token";
            authorization.IsValid.ShouldBe(false);

            authorization.AccessToken = "accessToken";
            authorization.IsValid.ShouldBe(true);
        }

        [Fact]
        public void TestTraktAuthorizationIsRefreshPossible()
        {
            var authorization = new TraktAuthorization();

            authorization.IsRefreshPossible.ShouldBe(false);

            authorization.RefreshToken = string.Empty;
            authorization.IsRefreshPossible.ShouldBe(false);

            authorization.RefreshToken = "refresh token";
            authorization.IsRefreshPossible.ShouldBe(false);

            authorization.RefreshToken = "refreshToken";
            authorization.IsRefreshPossible.ShouldBe(true);
        }

        [Fact]
        public void TestTraktAuthorizationIsExpired()
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;

            long utcNowSeconds = utcNow.Ticks / TimeSpan.TicksPerSecond;
            long originSeconds = origin.Ticks / TimeSpan.TicksPerSecond;
            long differenceSeconds = utcNowSeconds - originSeconds;

            var authorization = new TraktAuthorization
            {
                CreatedAt = (ulong)differenceSeconds
            };

            authorization.IsExpired.ShouldBe(true);

            authorization.AccessToken = string.Empty;
            authorization.IsExpired.ShouldBe(true);

            authorization.AccessToken = "access token";
            authorization.IsExpired.ShouldBe(true);

            authorization.AccessToken = "accessToken";
            authorization.IsExpired.ShouldBe(true);

            authorization.ExpiresIn = 1;
            authorization.IsExpired.ShouldBe(false);
        }

        [Fact]
        public void TestTraktAuthorizationIsExpiredWithIgnoreExpiration()
        {
            var authorization = new TraktAuthorization
            {
                IgnoreExpiration = true,
                ExpiresIn = 0
            };

            authorization.IsExpired.ShouldBe(true);

            authorization.AccessToken = string.Empty;
            authorization.IsExpired.ShouldBe(true);

            authorization.AccessToken = "access token";
            authorization.IsExpired.ShouldBe(true);

            authorization.AccessToken = "accessToken";
            authorization.IsExpired.ShouldBe(false);
        }

        [Fact]
        public void TestTraktAuthorizationCreatedAtDateTime()
        {
            var authorization = new TraktAuthorization();

            authorization.CreatedAtDateTime.ShouldBe(default);

            authorization.CreatedAt = 1487889741;
            authorization.CreatedAtDateTime.ShouldBe(CreatedAt);
        }

        [Fact]
        public void TestTraktAuthorizationToString()
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;

            long utcNowSeconds = utcNow.Ticks / TimeSpan.TicksPerSecond;
            long originSeconds = origin.Ticks / TimeSpan.TicksPerSecond;
            long differenceSeconds = utcNowSeconds - originSeconds;

            var authorization = new TraktAuthorization();

            authorization.ToString().ShouldBe("no valid access token (expired)");

            authorization.AccessToken = "accessToken";
            authorization.ToString().ShouldBe($"{authorization.AccessToken} (expired)");

            authorization.CreatedAt = (ulong)differenceSeconds;
            authorization.CreatedAtDateTime.ShouldBe(origin.AddSeconds(differenceSeconds));
            authorization.ExpiresIn = 600;
            authorization.ToString().ShouldBe($"{authorization.AccessToken} (valid until {authorization.CreatedAtDateTime.AddSeconds(authorization.ExpiresInSeconds)})");
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken!.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(true);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(false);
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(true);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(true);
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithExpiresInAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(1000, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken!.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(1000U);
            authorization.ExpiresInSeconds.ShouldBe(1000U);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(false);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(false);
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithExpiresInAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(1000, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(1000U);
            authorization.ExpiresInSeconds.ShouldBe(1000U);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(false);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(true);
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken!.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(true);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(false);
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(true);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(true);
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtExpiresInAccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, 1000, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken!.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(1000U);
            authorization.ExpiresInSeconds.ShouldBe(1000U);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(false);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(false);
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithCreatedAtExpiresInAccessTokenRefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(createdAtUtcNow, 1000, ACCESS_TOKEN, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(1000U);
            authorization.ExpiresInSeconds.ShouldBe(1000U);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(false);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(true);
        }

        [Fact]
        public void TestTraktAuthorizationCreateWithNullValues()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = CalculateTimestamp(createdAtUtcNow);

            var authorization = TraktAuthorization.CreateWith(null, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldNotBeNull();
            authorization.AccessToken!.ShouldBeEmpty();
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(true);
            authorization.IsExpired.ShouldBe(true);
            authorization.IsValid.ShouldBe(false);
            authorization.IsRefreshPossible.ShouldBe(true);

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken!.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(true);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(false);

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, null, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldNotBeNull();
            authorization.AccessToken!.ShouldBeEmpty();
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(false);
            authorization.IsExpired.ShouldBe(true);
            authorization.IsValid.ShouldBe(false);
            authorization.IsRefreshPossible.ShouldBe(true);

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken!.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(false);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(false);

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, null, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldNotBeNull();
            authorization.AccessToken!.ShouldBeEmpty();
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(true);
            authorization.IsExpired.ShouldBe(true);
            authorization.IsValid.ShouldBe(false);
            authorization.IsRefreshPossible.ShouldBe(true);

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken!.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(true);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(false);

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, EXPIRES_IN_SECONDS, null, REFRESH_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldNotBeNull();
            authorization.AccessToken!.ShouldBeEmpty();
            authorization.RefreshToken.ShouldBe(REFRESH_TOKEN);
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(false);
            authorization.IsExpired.ShouldBe(true);
            authorization.IsValid.ShouldBe(false);
            authorization.IsRefreshPossible.ShouldBe(true);

            // ----------------------------------------------------------------------------------------

            authorization = TraktAuthorization.CreateWith(createdAtUtcNow, EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            authorization.ShouldNotBeNull();
            authorization.AccessToken.ShouldBe(ACCESS_TOKEN);
            authorization.RefreshToken.ShouldNotBeNull();
            authorization.RefreshToken!.ShouldBeEmpty();
            authorization.ExpiresIn.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.ExpiresInSeconds.ShouldBe(EXPIRES_IN_SECONDS);
            authorization.CreatedAt.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtTimestamp.ShouldBe(createdAtUtcNowTimestamp);
            authorization.CreatedAtDateTime.ShouldBe(createdAtUtcNow, TimeSpan.FromSeconds(1));
            authorization.Scope.ShouldBe(TraktAccessScope.Public);
            authorization.TokenType.ShouldBe(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.ShouldBe(false);
            authorization.IsExpired.ShouldBe(false);
            authorization.IsValid.ShouldBe(true);
            authorization.IsRefreshPossible.ShouldBe(false);
        }

        private static ulong CalculateTimestamp(DateTime createdAt) => (ulong)new DateTimeOffset(createdAt).ToUnixTimeSeconds();
    }
}
