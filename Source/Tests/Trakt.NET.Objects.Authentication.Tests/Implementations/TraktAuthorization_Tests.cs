namespace TraktNet.Objects.Authentication.Tests.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [Category("Objects.Authentication.Implementations")]
    public class TraktAuthorization_Tests
    {
        private static readonly DateTime s_timestampOriginPlusCurrent = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1506271312);
        private const string ACCESS_TOKEN = "accessToken";
        private const string REFRESH_TOKEN = "refreshToken";
        private const uint EXPIRES_IN_SECONDS = 7776000;
        private static readonly DateTime s_createdAt = DateTime.UtcNow;
        private static readonly ulong s_createdAtTimestamp = TestUtility.CalculateTimestamp(s_createdAt);

        [Fact]
        public void Test_TraktAuthorization_Default_Constructor()
        {
            var traktAuthorization = new TraktAuthorization();

            traktAuthorization.AccessToken.Should().BeNull();
            traktAuthorization.RefreshToken.Should().BeNull();
            traktAuthorization.Scope.Should().BeNull();
            traktAuthorization.ExpiresInSeconds.Should().Be(0U);
            traktAuthorization.TokenType.Should().BeNull();
            traktAuthorization.CreatedAtTimestamp.Should().Be(0UL);
            traktAuthorization.IsExpired.Should().BeTrue();
            traktAuthorization.IsValid.Should().BeFalse();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();
            traktAuthorization.CreatedAt.Should().Be(default);
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public async Task Test_TraktAuthorization_From_Json()
        {
            var jsonReader = new AuthorizationObjectJsonReader();
            var traktAuthorization = await jsonReader.ReadObjectAsync(JSON) as TraktAuthorization;

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be("dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781");
            traktAuthorization.RefreshToken.Should().Be("76ba4c5c75c96f6087f58a4de10be6c00b29ea1ddc3b2022ee2016d1363e3a7c");
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(7776000U);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().Be(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(s_createdAtTimestamp));
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthorization_IsValid()
        {
            var traktAuthorization = new TraktAuthorization();

            traktAuthorization.IsValid.Should().BeFalse();

            traktAuthorization.AccessToken = string.Empty;
            traktAuthorization.IsValid.Should().BeFalse();

            traktAuthorization.AccessToken = "access token";
            traktAuthorization.IsValid.Should().BeFalse();

            traktAuthorization.AccessToken = "accessToken";
            traktAuthorization.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthorization_IsRefreshPossible()
        {
            var traktAuthorization = new TraktAuthorization();

            traktAuthorization.IsRefreshPossible.Should().BeFalse();

            traktAuthorization.RefreshToken = string.Empty;
            traktAuthorization.IsRefreshPossible.Should().BeFalse();

            traktAuthorization.RefreshToken = "refresh token";
            traktAuthorization.IsRefreshPossible.Should().BeFalse();

            traktAuthorization.RefreshToken = "refreshToken";
            traktAuthorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthorization_IsExpired()
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;
            const long ticksPerSecond = TimeSpan.TicksPerSecond;
            long utcNowSeconds = utcNow.Ticks / ticksPerSecond;
            long originSeconds = origin.Ticks / ticksPerSecond;
            long differenceSeconds = utcNowSeconds - originSeconds;

            var traktAuthorization = new TraktAuthorization
            {
                CreatedAtTimestamp = (ulong)differenceSeconds
            };

            traktAuthorization.IsExpired.Should().BeTrue();

            traktAuthorization.AccessToken = string.Empty;
            traktAuthorization.IsExpired.Should().BeTrue();

            traktAuthorization.AccessToken = "access token";
            traktAuthorization.IsExpired.Should().BeTrue();

            traktAuthorization.AccessToken = "accessToken";
            traktAuthorization.IsExpired.Should().BeTrue();

            traktAuthorization.ExpiresInSeconds = 1;
            traktAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthorization_IsExpired_With_IgnoreExpiration()
        {
            var traktAuthorization = new TraktAuthorization
            {
                IgnoreExpiration = true,
                ExpiresInSeconds = 0
            };

            traktAuthorization.IsExpired.Should().BeTrue();

            traktAuthorization.AccessToken = string.Empty;
            traktAuthorization.IsExpired.Should().BeTrue();

            traktAuthorization.AccessToken = "access token";
            traktAuthorization.IsExpired.Should().BeTrue();

            traktAuthorization.AccessToken = "accessToken";
            traktAuthorization.IsExpired.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthorization_CreatedAt()
        {
            var traktAuthorization = new TraktAuthorization();

            traktAuthorization.CreatedAt.Should().Be(default);

            traktAuthorization.CreatedAtTimestamp = 1506271312;
            traktAuthorization.CreatedAt.Should().Be(s_timestampOriginPlusCurrent);
        }

        [Fact]
        public void Test_TraktAuthorization_ToString()
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime utcNow = DateTime.UtcNow;
            const long ticksPerSecond = TimeSpan.TicksPerSecond;
            long utcNowSeconds = utcNow.Ticks / ticksPerSecond;
            long originSeconds = origin.Ticks / ticksPerSecond;
            long differenceSeconds = utcNowSeconds - originSeconds;

            var traktAuthorization = new TraktAuthorization();

            traktAuthorization.ToString().Should().Be("no valid access token (expired)");

            traktAuthorization.AccessToken = "accessToken";
            traktAuthorization.ToString().Should().Be($"{traktAuthorization.AccessToken} (expired)");

            traktAuthorization.CreatedAtTimestamp = (ulong)differenceSeconds;
            traktAuthorization.CreatedAt.Should().Be(origin.AddSeconds(differenceSeconds));
            traktAuthorization.ExpiresInSeconds = 600;
            traktAuthorization.ToString().Should().Be($"{traktAuthorization.AccessToken} (valid until {traktAuthorization.CreatedAt.AddSeconds(traktAuthorization.ExpiresInSeconds)})");
        }

        [Fact]
        public async Task Test_TraktAuthorization_Equals()
        {
            var traktAuthorization1 = new TraktAuthorization();
            var traktAuthorization2 = new TraktAuthorization();

            traktAuthorization1.Equals(traktAuthorization2).Should().BeTrue();

            var jsonReader = new AuthorizationObjectJsonReader();
            var traktAuthorizationFromJson = await jsonReader.ReadObjectAsync(JSON) as TraktAuthorization;

            traktAuthorization1 = CopyTraktAuthorization(traktAuthorizationFromJson);
            traktAuthorization2 = CopyTraktAuthorization(traktAuthorizationFromJson);

            traktAuthorization2.Equals(traktAuthorization1).Should().BeTrue();

            traktAuthorization1 = CopyTraktAuthorization(traktAuthorizationFromJson);
            traktAuthorization1.AccessToken = null;
            traktAuthorization2.Equals(traktAuthorization1).Should().BeFalse();

            traktAuthorization1 = CopyTraktAuthorization(traktAuthorizationFromJson);
            traktAuthorization1.RefreshToken = null;
            traktAuthorization2.Equals(traktAuthorization1).Should().BeFalse();

            traktAuthorization1 = CopyTraktAuthorization(traktAuthorizationFromJson);
            traktAuthorization1.ExpiresInSeconds = 0;
            traktAuthorization2.Equals(traktAuthorization1).Should().BeFalse();

            traktAuthorization1 = CopyTraktAuthorization(traktAuthorizationFromJson);
            traktAuthorization1.ExpiresInSeconds = 0;
            traktAuthorization2.Equals(traktAuthorization1).Should().BeFalse();

            traktAuthorization1 = CopyTraktAuthorization(traktAuthorizationFromJson);
            traktAuthorization1.Scope = null;
            traktAuthorization2.Equals(traktAuthorization1).Should().BeFalse();

            traktAuthorization1 = CopyTraktAuthorization(traktAuthorizationFromJson);
            traktAuthorization1.TokenType = null;
            traktAuthorization2.Equals(traktAuthorization1).Should().BeFalse();

            traktAuthorization1 = CopyTraktAuthorization(traktAuthorizationFromJson);
            traktAuthorization1.CreatedAtTimestamp = 0;
            traktAuthorization2.Equals(traktAuthorization1).Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_AccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = TestUtility.CalculateTimestamp(createdAtUtcNow);

            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(ACCESS_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().BeInRange(createdAtUtcNowTimestamp - 2, createdAtUtcNowTimestamp + 2);
            traktAuthorization.CreatedAt.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_AccessToken_And_RefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = TestUtility.CalculateTimestamp(createdAtUtcNow);

            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(ACCESS_TOKEN, REFRESH_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().BeInRange(createdAtUtcNowTimestamp - 2, createdAtUtcNowTimestamp + 2);
            traktAuthorization.CreatedAt.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_ExpiresIn_And_AccessToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = TestUtility.CalculateTimestamp(createdAtUtcNow);

            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().BeInRange(createdAtUtcNowTimestamp - 2, createdAtUtcNowTimestamp + 2);
            traktAuthorization.CreatedAt.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_ExpiresIn_And_AccessToken_And_RefreshToken()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = TestUtility.CalculateTimestamp(createdAtUtcNow);

            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, ACCESS_TOKEN, REFRESH_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().BeInRange(createdAtUtcNowTimestamp - 2, createdAtUtcNowTimestamp + 2);
            traktAuthorization.CreatedAt.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_CreatedAt_And_AccessToken()
        {
            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(s_createdAt, ACCESS_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().BeCloseTo(s_createdAt, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_CreatedAt_And_AccessToken_And_RefreshToken()
        {
            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(s_createdAt, ACCESS_TOKEN, REFRESH_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().BeCloseTo(s_createdAt, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_CreatedAt_And_ExpiresIn_And_AccessToken()
        {
            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(s_createdAt, EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().BeCloseTo(s_createdAt, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_CreatedAt_And_ExpiresIn_And_AccessToken_And_RefreshToken()
        {
            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(s_createdAt, EXPIRES_IN_SECONDS, ACCESS_TOKEN, REFRESH_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().BeCloseTo(s_createdAt, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktAuthorization_CreateWith_Null_Values()
        {
            DateTime createdAtUtcNow = DateTime.UtcNow;
            ulong createdAtUtcNowTimestamp = TestUtility.CalculateTimestamp(createdAtUtcNow);

            ITraktAuthorization traktAuthorization = TraktAuthorization.CreateWith(null, REFRESH_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().BeInRange(createdAtUtcNowTimestamp - 2, createdAtUtcNowTimestamp + 2);
            traktAuthorization.CreatedAt.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
            traktAuthorization.IsExpired.Should().BeTrue();
            traktAuthorization.IsValid.Should().BeFalse();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();

            // ------------------------------------------------------

            traktAuthorization = TraktAuthorization.CreateWith(ACCESS_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().BeInRange(createdAtUtcNowTimestamp - 2, createdAtUtcNowTimestamp + 2);
            traktAuthorization.CreatedAt.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();

            // ------------------------------------------------------
            // ------------------------------------------------------

            traktAuthorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, null, REFRESH_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().BeInRange(createdAtUtcNowTimestamp - 2, createdAtUtcNowTimestamp + 2);
            traktAuthorization.CreatedAt.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
            traktAuthorization.IsExpired.Should().BeTrue();
            traktAuthorization.IsValid.Should().BeFalse();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();

            // ------------------------------------------------------

            traktAuthorization = TraktAuthorization.CreateWith(EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().BeInRange(createdAtUtcNowTimestamp - 2, createdAtUtcNowTimestamp + 2);
            traktAuthorization.CreatedAt.Should().BeCloseTo(createdAtUtcNow, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();

            // ------------------------------------------------------
            // ------------------------------------------------------

            traktAuthorization = TraktAuthorization.CreateWith(s_createdAt, null, REFRESH_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().BeCloseTo(s_createdAt, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
            traktAuthorization.IsExpired.Should().BeTrue();
            traktAuthorization.IsValid.Should().BeFalse();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();

            // ------------------------------------------------------

            traktAuthorization = TraktAuthorization.CreateWith(s_createdAt, ACCESS_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().BeCloseTo(s_createdAt, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeTrue();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();

            // ------------------------------------------------------

            traktAuthorization = TraktAuthorization.CreateWith(s_createdAt, EXPIRES_IN_SECONDS, null, REFRESH_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.RefreshToken.Should().Be(REFRESH_TOKEN);
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().BeCloseTo(s_createdAt, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
            traktAuthorization.IsExpired.Should().BeTrue();
            traktAuthorization.IsValid.Should().BeFalse();
            traktAuthorization.IsRefreshPossible.Should().BeTrue();

            // ------------------------------------------------------

            traktAuthorization = TraktAuthorization.CreateWith(s_createdAt, EXPIRES_IN_SECONDS, ACCESS_TOKEN);

            traktAuthorization.Should().NotBeNull();
            traktAuthorization.AccessToken.Should().Be(ACCESS_TOKEN);
            traktAuthorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            traktAuthorization.Scope.Should().Be(TraktAccessScope.Public);
            traktAuthorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            traktAuthorization.ExpiresInSeconds.Should().Be(EXPIRES_IN_SECONDS);
            traktAuthorization.CreatedAtTimestamp.Should().Be(s_createdAtTimestamp);
            traktAuthorization.CreatedAt.Should().BeCloseTo(s_createdAt, TimeSpan.FromMilliseconds(1000));
            traktAuthorization.IgnoreExpiration.Should().BeFalse();
            traktAuthorization.IsExpired.Should().BeFalse();
            traktAuthorization.IsValid.Should().BeTrue();
            traktAuthorization.IsRefreshPossible.Should().BeFalse();
        }

        private static TraktAuthorization CopyTraktAuthorization(ITraktAuthorization traktAuthorization)
        {
            return new TraktAuthorization
            {
                AccessToken = traktAuthorization.AccessToken,
                RefreshToken = traktAuthorization.RefreshToken,
                Scope = traktAuthorization.Scope,
                TokenType = traktAuthorization.TokenType,
                ExpiresInSeconds = traktAuthorization.ExpiresInSeconds,
                CreatedAtTimestamp = traktAuthorization.CreatedAtTimestamp
            };
        }

        private readonly string JSON =
             "{" +
                "\"access_token\": \"dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781\"," +
                "\"refresh_token\": \"76ba4c5c75c96f6087f58a4de10be6c00b29ea1ddc3b2022ee2016d1363e3a7c\"," +
                "\"token_type\": \"bearer\"," +
                "\"expires_in\": 7776000," +
                "\"scope\": \"public\"," +
                $"\"created_at\": {s_createdAtTimestamp}" +
             "}";
    }
}