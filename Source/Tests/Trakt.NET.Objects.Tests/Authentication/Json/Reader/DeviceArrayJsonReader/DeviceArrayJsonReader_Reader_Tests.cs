namespace TraktNet.Objects.Tests.Authentication.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [Category("Objects.Authentication.JsonReader")]
    public partial class DeviceArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var objectJsonReader = new DeviceArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(jsonReader);
                traktDevices.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var objectJsonReader = new DeviceArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(jsonReader);

                traktDevices.Should().NotBeNull();
                ITraktDevice[] items = traktDevices.ToArray();

                items[0].Should().NotBeNull();
                items[0].DeviceCode.Should().Be("mockDeviceCode1");
                items[0].UserCode.Should().Be("mockUserCode1");
                items[0].VerificationUrl.Should().Be("mockUrl1");
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].IntervalInSeconds.Should().Be(600U);

                items[1].Should().NotBeNull();
                items[1].DeviceCode.Should().Be("mockDeviceCode2");
                items[1].UserCode.Should().Be("mockUserCode2");
                items[1].VerificationUrl.Should().Be("mockUrl2");
                items[1].ExpiresInSeconds.Should().Be(7200U);
                items[1].IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var objectJsonReader = new DeviceArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(jsonReader);

                traktDevices.Should().NotBeNull();
                ITraktDevice[] items = traktDevices.ToArray();

                items[0].Should().NotBeNull();
                items[0].DeviceCode.Should().BeNull();
                items[0].UserCode.Should().Be("mockUserCode1");
                items[0].VerificationUrl.Should().Be("mockUrl1");
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].IntervalInSeconds.Should().Be(600U);

                items[1].Should().NotBeNull();
                items[1].DeviceCode.Should().Be("mockDeviceCode2");
                items[1].UserCode.Should().Be("mockUserCode2");
                items[1].VerificationUrl.Should().Be("mockUrl2");
                items[1].ExpiresInSeconds.Should().Be(7200U);
                items[1].IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var objectJsonReader = new DeviceArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(jsonReader);

                traktDevices.Should().NotBeNull();
                ITraktDevice[] items = traktDevices.ToArray();

                items[0].Should().NotBeNull();
                items[0].DeviceCode.Should().Be("mockDeviceCode1");
                items[0].UserCode.Should().Be("mockUserCode1");
                items[0].VerificationUrl.Should().Be("mockUrl1");
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].IntervalInSeconds.Should().Be(600U);

                items[1].Should().NotBeNull();
                items[1].DeviceCode.Should().Be("mockDeviceCode2");
                items[1].UserCode.Should().BeNull();
                items[1].VerificationUrl.Should().BeNull();
                items[1].ExpiresInSeconds.Should().Be(0);
                items[1].IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var objectJsonReader = new DeviceArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(jsonReader);

                traktDevices.Should().NotBeNull();
                ITraktDevice[] items = traktDevices.ToArray();

                items[0].Should().NotBeNull();
                items[0].DeviceCode.Should().BeNull();
                items[0].UserCode.Should().Be("mockUserCode1");
                items[0].VerificationUrl.Should().Be("mockUrl1");
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].IntervalInSeconds.Should().Be(600U);

                items[1].Should().NotBeNull();
                items[1].DeviceCode.Should().Be("mockDeviceCode2");
                items[1].UserCode.Should().Be("mockUserCode2");
                items[1].VerificationUrl.Should().Be("mockUrl2");
                items[1].ExpiresInSeconds.Should().Be(7200U);
                items[1].IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var objectJsonReader = new DeviceArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(jsonReader);

                traktDevices.Should().NotBeNull();
                ITraktDevice[] items = traktDevices.ToArray();

                items[0].Should().NotBeNull();
                items[0].DeviceCode.Should().Be("mockDeviceCode1");
                items[0].UserCode.Should().Be("mockUserCode1");
                items[0].VerificationUrl.Should().Be("mockUrl1");
                items[0].ExpiresInSeconds.Should().Be(7200U);
                items[0].IntervalInSeconds.Should().Be(600U);

                items[1].Should().NotBeNull();
                items[1].DeviceCode.Should().BeNull();
                items[1].UserCode.Should().BeNull();
                items[1].VerificationUrl.Should().BeNull();
                items[1].ExpiresInSeconds.Should().Be(0);
                items[1].IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_JsonReader_Null()
        {
            var objectJsonReader = new DeviceArrayJsonReader();
            IEnumerable<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktDevices.Should().BeNull();
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var objectJsonReader = new DeviceArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                IEnumerable<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(jsonReader);
                traktDevices.Should().BeNull();
            }
        }
    }
}
