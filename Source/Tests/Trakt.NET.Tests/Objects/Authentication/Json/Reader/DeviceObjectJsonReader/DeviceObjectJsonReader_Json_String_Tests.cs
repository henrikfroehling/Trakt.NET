namespace TraktNet.Tests.Objects.Authentication.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [Category("Objects.Authentication.JsonReader")]
    public partial class DeviceObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().BeNull();
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().BeNull();
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().BeNull();
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(0);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(0);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().BeNull();
            traktDevice.VerificationUrl.Should().BeNull();
            traktDevice.ExpiresInSeconds.Should().Be(0);
            traktDevice.IntervalInSeconds.Should().Be(0);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().BeNull();
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().BeNull();
            traktDevice.ExpiresInSeconds.Should().Be(0);
            traktDevice.IntervalInSeconds.Should().Be(0);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().BeNull();
            traktDevice.UserCode.Should().BeNull();
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(0);
            traktDevice.IntervalInSeconds.Should().Be(0);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().BeNull();
            traktDevice.UserCode.Should().BeNull();
            traktDevice.VerificationUrl.Should().BeNull();
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(0);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().BeNull();
            traktDevice.UserCode.Should().BeNull();
            traktDevice.VerificationUrl.Should().BeNull();
            traktDevice.ExpiresInSeconds.Should().Be(0);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().BeNull();
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().BeNull();
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().BeNull();
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(0);
            traktDevice.IntervalInSeconds.Should().Be(600U);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().Be("mockDeviceCode");
            traktDevice.UserCode.Should().Be("mockUserCode");
            traktDevice.VerificationUrl.Should().Be("mockUrl");
            traktDevice.ExpiresInSeconds.Should().Be(7200U);
            traktDevice.IntervalInSeconds.Should().Be(0);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktDevice.Should().NotBeNull();
            traktDevice.DeviceCode.Should().BeNull();
            traktDevice.UserCode.Should().BeNull();
            traktDevice.VerificationUrl.Should().BeNull();
            traktDevice.ExpiresInSeconds.Should().Be(0);
            traktDevice.IntervalInSeconds.Should().Be(0);
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(default(string));
            traktDevice.Should().BeNull();
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(string.Empty);
            traktDevice.Should().BeNull();
        }
    }
}
