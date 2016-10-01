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
            ExpiresInSeconds = 7200,
            TokenType = TraktAccessTokenType.Bearer,
            IgnoreExpiration = false,
            Created = CREATED_AT
        };

        private static readonly string AUTHORIZATION_JSON =
            "{" +
                $"\"AccessToken\":\"{AUTHORIZATION.AccessToken}\"," +
                $"\"RefreshToken\":\"{AUTHORIZATION.RefreshToken}\"," +
                $"\"ExpiresIn\":{AUTHORIZATION.ExpiresInSeconds}," +
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
        public void TestTraktSerializationServiceSerializeEmptyTraktAuthorization()
        {
            var emptyAuthorization = new TraktAuthorization();

            string emptyAuthorizationJson =
            "{" +
                $"\"AccessToken\":\"\"," +
                $"\"RefreshToken\":\"\"," +
                $"\"ExpiresIn\":0," +
                $"\"Scope\":\"public\"," +
                $"\"TokenType\":\"bearer\"," +
                $"\"CreatedAtTicks\":{emptyAuthorization.Created.Ticks}," +
                $"\"IgnoreExpiration\":false" +
            "}";

            Action act = () => TraktSerializationService.Serialize(emptyAuthorization);
            act.ShouldNotThrow();

            var jsonAuthorization = TraktSerializationService.Serialize(emptyAuthorization);

            jsonAuthorization.Should().NotBeNullOrEmpty();
            jsonAuthorization.Should().Be(emptyAuthorizationJson);
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
        public void TestTraktSerializationServiceSerializeEmptyTraktDevice()
        {
            var emptyDevice = new TraktDevice();

            string emptyDeviceJson =
            "{" +
                $"\"UserCode\":\"\"," +
                $"\"DeviceCode\":\"\"," +
                $"\"VerificationUrl\":\"\"," +
                $"\"ExpiresInSeconds\":0," +
                $"\"IntervalInSeconds\":0," +
                $"\"CreatedAtTicks\":{emptyDevice.Created.Ticks}" +
            "}";

            Action act = () => TraktSerializationService.Serialize(emptyDevice);
            act.ShouldNotThrow();

            var jsonDevice = TraktSerializationService.Serialize(emptyDevice);

            jsonDevice.Should().NotBeNullOrEmpty();
            jsonDevice.Should().Be(emptyDeviceJson);
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
            var authorization = TraktSerializationService.DeserializeAuthorization(AUTHORIZATION_JSON);

            authorization.Should().NotBeNull();
            authorization.AccessToken.Should().Be(AUTHORIZATION.AccessToken);
            authorization.RefreshToken.Should().Be(AUTHORIZATION.RefreshToken);
            authorization.ExpiresInSeconds.Should().Be(AUTHORIZATION.ExpiresInSeconds);
            authorization.AccessScope.Should().Be(AUTHORIZATION.AccessScope);
            authorization.TokenType.Should().Be(AUTHORIZATION.TokenType);
            authorization.Created.Should().Be(AUTHORIZATION.Created);
            authorization.IgnoreExpiration.Should().Be(AUTHORIZATION.IgnoreExpiration);
        }

        [TestMethod]
        public void TestTraktSerializationServiceDeserializeTraktAuthorizationArgumentExceptions()
        {
            Action act = () => TraktSerializationService.DeserializeAuthorization(null);
            act.ShouldThrow<ArgumentException>();

            act = () => TraktSerializationService.DeserializeAuthorization(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktSerializationServiceDeserializeTraktAuthorizationInvalidJson()
        {
            Action act = () => TraktSerializationService.DeserializeAuthorization("{ \"invalid\": \"json\" }");
            act.ShouldNotThrow();

            var result = TraktSerializationService.DeserializeAuthorization("{ \"invalid\": \"json\" }");
            result.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSerializationServiceDeserializeTraktDevice()
        {
            var device = TraktSerializationService.DeserializeDevice(DEVICE_JSON);

            device.Should().NotBeNull();
            device.UserCode.Should().Be(DEVICE.UserCode);
            device.DeviceCode.Should().Be(DEVICE.DeviceCode);
            device.VerificationUrl.Should().Be(DEVICE.VerificationUrl);
            device.ExpiresInSeconds.Should().Be(DEVICE.ExpiresInSeconds);
            device.IntervalInSeconds.Should().Be(DEVICE.IntervalInSeconds);
            device.Created.Should().Be(DEVICE.Created);
        }

        [TestMethod]
        public void TestTraktSerializationServiceDeserializeTraktDeviceArgumentExceptions()
        {
            Action act = () => TraktSerializationService.DeserializeDevice(null);
            act.ShouldThrow<ArgumentException>();

            act = () => TraktSerializationService.DeserializeDevice(string.Empty);
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktSerializationServiceDeserializeTraktDeviceInvalidJson()
        {
            Action act = () => TraktSerializationService.DeserializeDevice("{ \"invalid\": \"json\" }");
            act.ShouldNotThrow();

            var result = TraktSerializationService.DeserializeDevice("{ \"invalid\": \"json\" }");
            result.Should().BeNull();
        }
    }
}
