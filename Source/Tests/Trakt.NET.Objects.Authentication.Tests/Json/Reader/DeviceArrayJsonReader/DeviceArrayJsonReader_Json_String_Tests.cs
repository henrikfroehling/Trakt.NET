namespace TraktNet.Objects.Authentication.Tests.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Authentication.JsonReader")]
    public partial class DeviceArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var objectJsonReader = new ArrayJsonReader<ITraktDevice>();
            IList<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktDevices.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_Json_String_Complete()
        {
            var objectJsonReader = new ArrayJsonReader<ITraktDevice>();
            IList<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var objectJsonReader = new ArrayJsonReader<ITraktDevice>();
            IList<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var objectJsonReader = new ArrayJsonReader<ITraktDevice>();
            IList<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var objectJsonReader = new ArrayJsonReader<ITraktDevice>();
            IList<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var objectJsonReader = new ArrayJsonReader<ITraktDevice>();
            IList<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_Json_String_Null()
        {
            var objectJsonReader = new ArrayJsonReader<ITraktDevice>();
            Func<Task<IList<ITraktDevice>>> traktDevices = () => objectJsonReader.ReadArrayAsync(default(string));
            await traktDevices.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_DeviceArrayJsonReader_ReadObject_From_Json_String_Empty()
        {
            var objectJsonReader = new ArrayJsonReader<ITraktDevice>();
            IList<ITraktDevice> traktDevices = await objectJsonReader.ReadArrayAsync(string.Empty);
            traktDevices.Should().BeNull();
        }
    }
}
