namespace TraktNet.Tests.Objects.Authentication.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Writer;
    using Xunit;

    [Category("Objects.Authentication.JsonWriter")]
    public partial class DeviceObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_DeviceObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new DeviceObjectJsonWriter();
            ITraktDevice traktDevice = new TraktDevice();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktDevice));
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_Object_Empty()
        {
            ITraktDevice traktDevice = new TraktDevice();
            var traktJsonWriter = new DeviceObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktDevice);
            json.Should().Be("{}");
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_Object_Only_DeviceCode_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                DeviceCode = "mockDeviceCode"
            };

            var traktJsonWriter = new DeviceObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktDevice);
            json.Should().Be(@"{""device_code"":""mockDeviceCode""}");
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_Object_Only_UserCode_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                UserCode = "mockUserCode"
            };

            var traktJsonWriter = new DeviceObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktDevice);
            json.Should().Be(@"{""user_code"":""mockUserCode""}");
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_Object_Only_VerificationUrl_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                VerificationUrl = "mockUrl"
            };

            var traktJsonWriter = new DeviceObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktDevice);
            json.Should().Be(@"{""verification_url"":""mockUrl""}");
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_Object_Only_ExpiresInSeconds_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                ExpiresInSeconds = 7200
            };

            var traktJsonWriter = new DeviceObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktDevice);
            json.Should().Be(@"{""expires_in"":7200}");
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_Object_Only_IntervalInSeconds_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                IntervalInSeconds = 600
            };

            var traktJsonWriter = new DeviceObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktDevice);
            json.Should().Be(@"{""interval"":600}");
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "mockUserCode",
                VerificationUrl = "mockUrl",
                ExpiresInSeconds = 7200,
                IntervalInSeconds = 600
            };

            var traktJsonWriter = new DeviceObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktDevice);
            json.Should().Be(@"{""device_code"":""mockDeviceCode"",""user_code"":""mockUserCode""," +
                                @"""verification_url"":""mockUrl"",""expires_in"":7200,""interval"":600}");
        }
    }
}
