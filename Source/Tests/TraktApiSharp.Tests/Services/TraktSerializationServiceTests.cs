namespace TraktApiSharp.Tests.Services
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using TraktApiSharp.Authentication;
    using TraktApiSharp.Enums;
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
            "{" +
                $"\"AccessToken\":\"{AUTHORIZATION.AccessToken}\"," +
                $"\"RefreshToken\":\"{AUTHORIZATION.RefreshToken}\"," +
                $"\"ExpiresIn\":{AUTHORIZATION.ExpiresIn}," +
                $"\"Scope\":\"{AUTHORIZATION.AccessScope.ObjectName}\"," +
                $"\"TokenType\":\"{AUTHORIZATION.TokenType.ObjectName}\"," +
                $"\"CreatedAtTicks\":{CREATED_AT.Ticks}," +
                $"\"IgnoreExpiration\":{AUTHORIZATION.IgnoreExpiration.ToString().ToLower()}" +
            "}";

        private static readonly TraktDevice DEVICE = new TraktDevice
        {
            UserCode = "5055CC52",
            DeviceCode = "d9c126a7706328d808914cfd1e40274b6e009f684b1aca271b9b3f90b3630d64",
            VerificationUrl = "https://trakt.tv/activate",
            ExpiresInSeconds = 600,
            IntervalInSeconds = 5,
            Created = CREATED_AT
        };

        private static readonly string DEVICE_JSON =
            "{" +
                $"\"UserCode\":\"{DEVICE.UserCode}\"," +
                $"\"DeviceCode\":\"{DEVICE.DeviceCode}\"," +
                $"\"VerificationUrl\":\"{DEVICE.VerificationUrl}\"," +
                $"\"ExpiresInSeconds\":{DEVICE.ExpiresInSeconds}," +
                $"\"IntervalInSeconds\":{DEVICE.IntervalInSeconds}," +
                $"\"CreatedAtTicks\":{CREATED_AT.Ticks}" +
            "}";

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
            Action act = () => TraktSerializationService.Serialize(default(TraktAuthorization));
            act.ShouldThrow<ArgumentNullException>();
        }

        [TestMethod]
        public void TestTraktSerializationServiceSerializeTraktDevice()
        {
            var jsonDevice = TraktSerializationService.Serialize(DEVICE);

            jsonDevice.Should().NotBeNullOrEmpty();
            jsonDevice.Should().Be(DEVICE_JSON);
        }

        [TestMethod]
        public void TestTraktSerializationServiceSerializeTraktDeviceArgumentExceptions()
        {
            Action act = () => TraktSerializationService.Serialize(default(TraktDevice));
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
