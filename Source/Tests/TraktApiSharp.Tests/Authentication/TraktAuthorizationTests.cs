namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Enums;
    using Utils;

    [TestClass]
    public class TraktAuthorizationTests
    {
        [TestMethod]
        public void TestTraktAuthorizationDefaultConstructor()
        {
            var dtNowUtc = DateTime.UtcNow;

            var token = new TraktAuthorization();

            token.AccessToken.Should().BeNullOrEmpty();
            token.AccessScope.Should().BeNull();
            token.TokenType.Should().BeNull();
            token.ExpiresInSeconds.Should().Be(0);
            token.RefreshToken.Should().BeNullOrEmpty();
            token.IsValid.Should().BeFalse();
            token.IsRefreshPossible.Should().BeFalse();
            token.IsExpired.Should().BeTrue();
            token.Created.Should().BeCloseTo(dtNowUtc);
            token.IgnoreExpiration.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthorizationReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Authentication\AccessToken.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var token = JsonConvert.DeserializeObject<TraktAuthorization>(jsonFile);

            token.Should().NotBeNull();
            token.AccessToken.Should().Be("dbaf9757982a9e738f05d249b7b5b4a266b3a139049317c4909f2f263572c781");
            token.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            token.ExpiresInSeconds.Should().Be(7200);
            token.RefreshToken.Should().Be("76ba4c5c75c96f6087f58a4de10be6c00b29ea1ddc3b2022ee2016d1363e3a7c");
            token.AccessScope.Should().Be(TraktAccessScope.Public);
            token.IsExpired.Should().BeFalse();
            token.IsValid.Should().BeTrue();
            token.IsRefreshPossible.Should().BeTrue();
            token.IgnoreExpiration.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthorizationIsValid()
        {
            var token = new TraktAuthorization();
            token.IsValid.Should().BeFalse();

            token.AccessToken = string.Empty;
            token.IsValid.Should().BeFalse();

            token.AccessToken = "access token";
            token.IsValid.Should().BeFalse();

            token.AccessToken = "accessToken";
            token.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktAuthorizationIsRefreshPossible()
        {
            var token = new TraktAuthorization();
            token.IsRefreshPossible.Should().BeFalse();

            token.RefreshToken = string.Empty;
            token.IsRefreshPossible.Should().BeFalse();

            token.RefreshToken = "refresh token";
            token.IsRefreshPossible.Should().BeFalse();

            token.RefreshToken = "refreshToken";
            token.IsRefreshPossible.Should().BeTrue();
        }

        [TestMethod]
        public void TestTraktAuthorizationIsExpired()
        {
            var token = new TraktAuthorization();
            token.IsExpired.Should().BeTrue();

            token.AccessToken = string.Empty;
            token.IsExpired.Should().BeTrue();

            token.AccessToken = "access token";
            token.IsExpired.Should().BeTrue();

            token.AccessToken = "accessToken";
            token.IsExpired.Should().BeTrue();

            token.ExpiresInSeconds = 1;
            token.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthorizationIsExpiredWithIgnoreExpiration()
        {
            var token = new TraktAuthorization();
            token.IgnoreExpiration = true;
            token.ExpiresInSeconds = 0;

            token.IsExpired.Should().BeTrue();

            token.AccessToken = string.Empty;
            token.IsExpired.Should().BeTrue();

            token.AccessToken = "access token";
            token.IsExpired.Should().BeTrue();

            token.AccessToken = "accessToken";
            token.IsExpired.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthorizationCreateWithAccessToken()
        {
            var accessToken = "accessToken";

            var authorization = TraktAuthorization.CreateWith(accessToken);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(accessToken);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.AccessScope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.ExpiresInSeconds.Should().Be(0);
        }

        [TestMethod]
        public void TestTraktAuthorizationCreateWithAccessTokenAndRefreshToken()
        {
            var accessToken = "accessToken";
            var refreshToken = "refreshToken";

            var authorization = TraktAuthorization.CreateWith(accessToken, refreshToken);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(accessToken);
            authorization.RefreshToken.Should().Be(refreshToken);
            authorization.AccessScope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeTrue();
            authorization.ExpiresInSeconds.Should().Be(0);
        }

        [TestMethod]
        public void TestTraktAuthorizationCreateWithCreatedAtAndExpiresInAndAccessToken()
        {
            var createdAt = DateTime.Now;
            var expiresIn = 3600 * 24 * 90;

            var accessToken = "accessToken";

            var authorization = TraktAuthorization.CreateWith(createdAt, expiresIn, accessToken);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(accessToken);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
            authorization.AccessScope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.Created.Should().Be(createdAt.ToUniversalTime());
            authorization.ExpiresInSeconds.Should().Be(expiresIn);
        }

        [TestMethod]
        public void TestTraktAuthorizationCreateWithCreatedAtAndExpiresInAndAccessTokenAndRefreshToken()
        {
            var createdAt = DateTime.Now;
            var expiresIn = 3600 * 24 * 90;

            var accessToken = "accessToken";
            var refreshToken = "refreshToken";

            var authorization = TraktAuthorization.CreateWith(createdAt, expiresIn, accessToken, refreshToken);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(accessToken);
            authorization.RefreshToken.Should().Be(refreshToken);
            authorization.AccessScope.Should().Be(TraktAccessScope.Public);
            authorization.TokenType.Should().Be(TraktAccessTokenType.Bearer);
            authorization.IgnoreExpiration.Should().BeFalse();
            authorization.Created.Should().Be(createdAt.ToUniversalTime());
            authorization.ExpiresInSeconds.Should().Be(expiresIn);
        }

        [TestMethod]
        public void TestTraktAuthorizationCreateWithNullValues()
        {
            var createdAt = DateTime.Now;
            var expiresIn = 3600 * 24 * 90;

            var accessToken = "accessToken";
            var refreshToken = "refreshToken";

            var authorization = TraktAuthorization.CreateWith(null, refreshToken);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().Be(refreshToken);

            authorization = TraktAuthorization.CreateWith(accessToken);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(accessToken);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();

            authorization = TraktAuthorization.CreateWith(createdAt, expiresIn, null, refreshToken);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().NotBeNull().And.BeEmpty();
            authorization.RefreshToken.Should().Be(refreshToken);

            authorization = TraktAuthorization.CreateWith(createdAt, expiresIn, accessToken);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(accessToken);
            authorization.RefreshToken.Should().NotBeNull().And.BeEmpty();
        }
    }
}
