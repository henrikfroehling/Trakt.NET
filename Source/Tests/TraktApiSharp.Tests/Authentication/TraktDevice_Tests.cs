namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using Traits;
    using TraktApiSharp.Authentication;
    using Xunit;

    [Category("Authentication")]
    public class TraktDevice_Tests
    {
        [Fact]
        public void TestTraktDeviceDefaultConstructor()
        {
            var dtNowUtc = DateTime.UtcNow;

            var device = new TraktDevice();

            device.DeviceCode.Should().BeNullOrEmpty();
            device.UserCode.Should().BeNullOrEmpty();
            device.VerificationUrl.Should().BeNullOrEmpty();
            device.ExpiresInSeconds.Should().Be(0);
            device.IntervalInSeconds.Should().Be(0);
            device.IsExpiredUnused.Should().BeTrue();
            device.IsValid.Should().BeFalse();
            device.Created.Should().BeCloseTo(dtNowUtc);
        }

        [Fact]
        public void TestTraktDeviceReadFromJson()
        {
            var device = JsonConvert.DeserializeObject<TraktDevice>(JSON);

            device.Should().NotBeNull();
            device.DeviceCode.Should().Be("d9c126a7706328d808914cfd1e40274b6e009f684b1aca271b9b3f90b3630d64");
            device.UserCode.Should().Be("5055CC52");
            device.VerificationUrl.Should().Be("https://trakt.tv/activate");
            device.ExpiresInSeconds.Should().Be(600);
            device.IntervalInSeconds.Should().Be(5);
            device.IsExpiredUnused.Should().BeFalse();
            device.IsValid.Should().BeTrue();
        }

        private const string JSON =
            @"{
                ""device_code"": ""d9c126a7706328d808914cfd1e40274b6e009f684b1aca271b9b3f90b3630d64"",
                ""user_code"": ""5055CC52"",
                ""verification_url"": ""https://trakt.tv/activate"",
                ""expires_in"": 600,
                ""interval"": 5
              }";
    }
}
