namespace TraktNet.Objects.Authentication.Tests.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [Category("Objects.Authentication.JsonReader")]
    public partial class DeviceObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktDevice.Should().BeNull();
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(jsonReader);
                traktDevice.Should().BeNull();
            }
        }
    }
}
