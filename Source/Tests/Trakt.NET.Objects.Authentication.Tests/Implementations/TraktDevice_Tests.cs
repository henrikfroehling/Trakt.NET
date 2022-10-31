namespace TraktNet.Objects.Authentication.Tests.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Authentication.Implementations")]
    public class TraktDevice_Tests
    {
        [Fact]
        public void Test_TraktDevice_Default_Constructor()
        {
            var traktDevice = new TraktDevice();

            traktDevice.DeviceCode.Should().BeNull();
            traktDevice.UserCode.Should().BeNull();
            traktDevice.VerificationUrl.Should().BeNull();
            traktDevice.ExpiresInSeconds.Should().Be(0U);
            traktDevice.IntervalInSeconds.Should().Be(0U);
            traktDevice.IntervalInMilliseconds.Should().Be(0U);
            traktDevice.IsValid.Should().BeFalse();
            traktDevice.IsExpiredUnused.Should().BeTrue();
            traktDevice.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(1000));
        }

        [Fact]
        public async Task Test_TraktDevice_From_Json()
        {
            var jsonReader = new DeviceObjectJsonReader();
            var traktDevice = await jsonReader.ReadObjectAsync(JSON) as TraktDevice;

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("194e624d66681668632a29292d72b87cb02d4e231d428d3136e596af9e5f942f");
            traktDevice.UserCode.Should().Be("0F843E93");
            traktDevice.VerificationUrl.Should().Be("https://trakt.tv/activate");
            traktDevice.ExpiresInSeconds.Should().Be(600U);
            traktDevice.IntervalInSeconds.Should().Be(5U);
            traktDevice.IntervalInMilliseconds.Should().Be(5000U);
            traktDevice.IsValid.Should().BeTrue();
            traktDevice.IsExpiredUnused.Should().BeFalse();
            traktDevice.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(1000));
        }

        [Fact]
        public void Test_TraktDevice_IsValid()
        {
            var traktDevice = new TraktDevice();

            traktDevice.IsValid.Should().BeFalse();

            traktDevice.DeviceCode = "deviceCode";
            traktDevice.IsValid.Should().BeFalse();

            traktDevice.UserCode = "userCode";
            traktDevice.IsValid.Should().BeFalse();

            traktDevice.VerificationUrl = "verificationUrl";
            traktDevice.IsValid.Should().BeFalse();

            traktDevice.IntervalInSeconds = 1;
            traktDevice.IsValid.Should().BeFalse();

            traktDevice.ExpiresInSeconds = 600;
            traktDevice.IsExpiredUnused.Should().BeFalse();
            traktDevice.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktDevice_IsExpiredUnused()
        {
            var traktDevice = new TraktDevice();

            traktDevice.IsExpiredUnused.Should().BeTrue();

            traktDevice.ExpiresInSeconds = 600;
            traktDevice.IsExpiredUnused.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktDevice_ToString()
        {
            var traktDevice = new TraktDevice();

            traktDevice.ToString().Should().Be("no valid device code (expired unused)");

            traktDevice.DeviceCode = "deviceCode";
            traktDevice.ToString().Should().Be($"{traktDevice.DeviceCode} (expired unused)");

            traktDevice.ExpiresInSeconds = 600;
            traktDevice.IsExpiredUnused.Should().BeFalse();
            traktDevice.ToString().Should().Be($"{traktDevice.DeviceCode} (valid until {traktDevice.CreatedAt.AddSeconds(traktDevice.ExpiresInSeconds)})");
        }

        [Fact]
        public async Task Test_TraktDevice_Equals()
        {
            var traktDevice1 = new TraktDevice();
            var traktDevice2 = new TraktDevice();

            traktDevice1.Equals(traktDevice2).Should().BeTrue();

            var jsonReader = new DeviceObjectJsonReader();
            var traktDeviceFromJson = await jsonReader.ReadObjectAsync(JSON) as TraktDevice;

            traktDevice1 = CopyTraktDevice(traktDeviceFromJson);
            traktDevice2 = CopyTraktDevice(traktDeviceFromJson);

            traktDevice2.Equals(traktDevice1).Should().BeTrue();

            traktDevice1 = CopyTraktDevice(traktDeviceFromJson);
            traktDevice1.DeviceCode = null;
            traktDevice2.Equals(traktDevice1).Should().BeFalse();

            traktDevice1 = CopyTraktDevice(traktDeviceFromJson);
            traktDevice1.UserCode = null;
            traktDevice2.Equals(traktDevice1).Should().BeFalse();

            traktDevice1 = CopyTraktDevice(traktDeviceFromJson);
            traktDevice1.VerificationUrl = null;
            traktDevice2.Equals(traktDevice1).Should().BeFalse();

            traktDevice1 = CopyTraktDevice(traktDeviceFromJson);
            traktDevice1.ExpiresInSeconds = 0;
            traktDevice2.Equals(traktDevice1).Should().BeFalse();

            traktDevice1 = CopyTraktDevice(traktDeviceFromJson);
            traktDevice1.IntervalInSeconds = 0;
            traktDevice2.Equals(traktDevice1).Should().BeFalse();
        }

        private static TraktDevice CopyTraktDevice(ITraktDevice traktDevice)
        {
            return new TraktDevice
            {
                DeviceCode = traktDevice.DeviceCode,
                UserCode = traktDevice.UserCode,
                VerificationUrl = traktDevice.VerificationUrl,
                ExpiresInSeconds = traktDevice.ExpiresInSeconds,
                IntervalInSeconds = traktDevice.IntervalInSeconds
            };
        }

        private const string JSON =
            @"{
                ""device_code"": ""194e624d66681668632a29292d72b87cb02d4e231d428d3136e596af9e5f942f"",
                ""user_code"": ""0F843E93"",
                ""verification_url"": ""https://trakt.tv/activate"",
                ""expires_in"": 600,
                ""interval"": 5
              }";
    }
}