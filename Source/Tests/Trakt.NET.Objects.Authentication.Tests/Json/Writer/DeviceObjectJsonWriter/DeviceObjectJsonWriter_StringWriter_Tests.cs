namespace TraktNet.Objects.Authentication.Tests.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Writer;
    using Xunit;

    [Category("Objects.Authentication.JsonWriter")]
    public partial class DeviceObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_DeviceObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new DeviceObjectJsonWriter();
            ITraktDevice traktDevice = new TraktDevice();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktDevice);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_StringWriter_Empty()
        {
            ITraktDevice traktDevice = new TraktDevice();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new DeviceObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktDevice);
                json.Should().Be("{}");
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_StringWriter_Only_DeviceCode_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                DeviceCode = "mockDeviceCode"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new DeviceObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktDevice);
                json.Should().Be(@"{""device_code"":""mockDeviceCode""}");
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_StringWriter_Only_UserCode_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                UserCode = "mockUserCode"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new DeviceObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktDevice);
                json.Should().Be(@"{""user_code"":""mockUserCode""}");
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_StringWriter_Only_VerificationUrl_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                VerificationUrl = "mockUrl"
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new DeviceObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktDevice);
                json.Should().Be(@"{""verification_url"":""mockUrl""}");
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_StringWriter_Only_ExpiresInSeconds_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                ExpiresInSeconds = 7200
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new DeviceObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktDevice);
                json.Should().Be(@"{""expires_in"":7200}");
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_StringWriter_Only_IntervalInSeconds_Property()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                IntervalInSeconds = 600
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new DeviceObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktDevice);
                json.Should().Be(@"{""interval"":600}");
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktDevice traktDevice = new TraktDevice
            {
                DeviceCode = "mockDeviceCode",
                UserCode = "mockUserCode",
                VerificationUrl = "mockUrl",
                ExpiresInSeconds = 7200,
                IntervalInSeconds = 600
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new DeviceObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktDevice);
                json.Should().Be(@"{""device_code"":""mockDeviceCode"",""user_code"":""mockUserCode""," +
                                 @"""verification_url"":""mockUrl"",""expires_in"":7200,""interval"":600}");
            }
        }
    }
}
