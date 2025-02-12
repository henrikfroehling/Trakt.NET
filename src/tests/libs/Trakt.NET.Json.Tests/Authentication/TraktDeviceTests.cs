namespace TraktNET.Json.Authentication
{
    public sealed class TraktDeviceTests
    {
        [Fact]
        public void TestTraktDeviceConstructor()
        {
            var device = new TraktDevice();

            device.DeviceCode.ShouldBeNull();
            device.UserCode.ShouldBeNull();
            device.VerificationUrl.ShouldBeNull();
            device.ExpiresIn.ShouldBeNull();
            device.ExpiresInSeconds.ShouldBe(0U);
            device.Interval.ShouldBeNull();
            device.IntervalInMilliseconds.ShouldBe(0U);
            device.IntervalInSeconds.ShouldBe(0U);
            device.CreatedAt.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            device.IsValid.ShouldBe(false);
            device.IsExpiredUnused.ShouldBe(true);
        }

        [Fact]
        public async Task TestTraktDeviceFromJson()
        {
            TraktDevice? device = await TraktTestUtility.DeserializeJsonAsync<TraktDevice>("Authentication\\device.json");

            device.ShouldNotBeNull();

            device!.DeviceCode.ShouldBe("d9c126a7706328d808914cfd1e40274b6e009f684b1aca271b9b3f90b3630d64");
            device!.UserCode.ShouldBe("5055CC52");
            device!.VerificationUrl.ShouldBe("https://trakt.tv/activate");
            device!.ExpiresIn.ShouldBe(600U);
            device!.ExpiresInSeconds.ShouldBe(600U);
            device!.Interval.ShouldBe(5U);
            device!.IntervalInMilliseconds.ShouldBe(5000U);
            device!.IntervalInSeconds.ShouldBe(5U);
            device!.CreatedAt.ShouldBe(DateTime.UtcNow, TimeSpan.FromSeconds(1));
            device!.IsValid.ShouldBe(true);
            device!.IsExpiredUnused.ShouldBe(false);
        }

        [Fact]
        public void TestTraktDeviceIsValid()
        {
            var device = new TraktDevice();

            device.IsValid.ShouldBe(false);

            device.DeviceCode = "deviceCode";
            device.IsValid.ShouldBe(false);

            device.UserCode = "userCode";
            device.IsValid.ShouldBe(false);

            device.VerificationUrl = "verificationUrl";
            device.IsValid.ShouldBe(false);

            device.Interval = 1;
            device.IsValid.ShouldBe(false);

            device.ExpiresIn = 600;
            device.IsExpiredUnused.ShouldBe(false);
            device.IsValid.ShouldBe(true);
        }

        [Fact]
        public void TestTraktDeviceIsExpiredUnused()
        {
            var device = new TraktDevice();

            device.IsExpiredUnused.ShouldBe(true);

            device.ExpiresIn = 600;
            device.IsExpiredUnused.ShouldBe(false);
        }

        [Fact]
        public void TestTraktDeviceToString()
        {
            var device = new TraktDevice();

            device.ToString().ShouldBe("no valid device code (expired unused)");

            device.DeviceCode = "deviceCode";
            device.UserCode = "userCode";
            device.VerificationUrl = "https://trakt.tv/activate";
            device.Interval = 5;
            device.ToString().ShouldBe("no valid device code (expired unused)");

            device.ExpiresIn = 600;
            device.IsExpiredUnused.ShouldBe(false);
            device.ToString().ShouldBe($"{device.DeviceCode} (valid until {device.CreatedAt.AddSeconds(device.ExpiresInSeconds)})");
        }
    }
}
