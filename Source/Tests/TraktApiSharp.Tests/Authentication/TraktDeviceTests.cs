namespace TraktApiSharp.Tests.Authentication
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Authentication;
    using Utils;

    [TestClass]
    public class TraktDeviceTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            var dtNowUtc = DateTime.UtcNow;

            var device = new TraktDevice();

            device.Created.Should().BeCloseTo(dtNowUtc);
        }

        [TestMethod]
        public void TestReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Authentication\Device.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var device = JsonConvert.DeserializeObject<TraktDevice>(jsonFile);

            device.DeviceCode.Should().Be("d9c126a7706328d808914cfd1e40274b6e009f684b1aca271b9b3f90b3630d64");
            device.UserCode.Should().Be("5055CC52");
            device.VerificationUrl.Should().Be("https://trakt.tv/activate");
            device.ExpiresInSeconds.Should().Be(600);
            device.Interval.Should().Be(5);
            device.IsExpiredUnused.Should().BeFalse();
            device.IsValid.Should().BeTrue();
        }
    }
}
