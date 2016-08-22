namespace TraktApiSharp.Tests.Services
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Services;

    [TestClass]
    public class TraktSerializationServiceTests
    {
        private static readonly DateTime CREATED_AT = DateTime.UtcNow;

        private static readonly TraktAuthorization AUTHORIZATION = new TraktAuthorization
        {
            AccessScope = TraktAccessScope.Public,
            AccessToken = "accessToken",
            RefreshToken = "refreshToken",
            ExpiresIn = 7200,
            TokenType = TraktAccessTokenType.Bearer,
            IgnoreExpiration = false,
            Created = CREATED_AT
        };

        private static readonly string AUTHORIZATION_JSON =
            $"{{" +
                $"\"AccessToken\":\"{AUTHORIZATION.AccessToken}\"," +
                $"\"RefreshToken\":\"{AUTHORIZATION.RefreshToken}\"," +
                $"\"ExpiresIn\":{AUTHORIZATION.ExpiresIn}," +
                $"\"Scope\":\"{AUTHORIZATION.AccessScope.ObjectName}\"," +
                $"\"TokenType\":\"{AUTHORIZATION.TokenType.ObjectName}\"," +
                $"\"CreatedAt\":\"{CREATED_AT.ToTraktLongDateTimeString()}\"," +
                $"\"IgnoreExpiration\":{AUTHORIZATION.IgnoreExpiration.ToString().ToLower()}" +
            $"}}";

        [TestMethod]
        public void TestTraktSerializationServiceSerializeTraktAuthorization()
        {
            var jsonAuthorization = TraktSerializationService.Serialize(AUTHORIZATION);

            jsonAuthorization.Should().NotBeNullOrEmpty();
            jsonAuthorization.Should().Be(AUTHORIZATION_JSON);
        }

        [TestMethod]
        public void TestTraktSerializationServiceSerializeTraktAuthorizationArgumentExceptions()
        {
            Action act = () => TraktSerializationService.Serialize(null);
            act.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void TestTraktSerializationServiceDeserializeTraktAuthorization()
        {
            var authorization = TraktSerializationService.Deserialize(AUTHORIZATION_JSON);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(AUTHORIZATION.AccessToken);
            authorization.RefreshToken.Should().Be(AUTHORIZATION.RefreshToken);
            authorization.ExpiresIn.Should().Be(AUTHORIZATION.ExpiresIn);
            authorization.AccessScope.Should().Be(AUTHORIZATION.AccessScope);
            authorization.TokenType.Should().Be(AUTHORIZATION.TokenType);
            authorization.Created.Should().Be(AUTHORIZATION.Created);
            authorization.IgnoreExpiration.Should().Be(AUTHORIZATION.IgnoreExpiration);
        }

        [TestMethod]
        public void TestTraktSerializationServiceDeserializeTraktAuthorizationArgumentExceptions()
        {
            Action act = () => TraktSerializationService.Deserialize(null);
            act.ShouldThrow<ArgumentException>();

            act = () => TraktSerializationService.Deserialize(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }
    }
}
