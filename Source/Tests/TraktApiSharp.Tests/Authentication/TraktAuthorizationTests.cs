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
            token.IsExpired.Should().BeFalse();
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
            token.IsExpired.Should().BeTrue();
            token.IgnoreExpiration.Should().BeFalse();
        }

        [TestMethod]
        public void TestTraktAuthorizationIsValid()
        {
            var token = new TraktAuthorization();
            token.IsExpired.Should().BeFalse();

            token.ExpiresInSeconds = 3600;
            token.IsExpired.Should().BeFalse();

            token.AccessToken = "acces token";
            token.IsExpired.Should().BeFalse();

            token.AccessToken = "accessToken";
            token.IsExpired.Should().BeTrue();

            token = new TraktAuthorization();
            token.IgnoreExpiration = true;
            token.IsExpired.Should().BeFalse();

            token.AccessToken = "access token";
            token.IsExpired.Should().BeFalse();

            token.AccessToken = "accessToken";
            token.IsExpired.Should().BeTrue();
        }
    }
}
