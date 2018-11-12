namespace TraktNet.Tests.Objects.Authentication.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Authentication;
    using TraktNet.Objects.Authentication.Json.Reader;
    using Xunit;

    [Category("Objects.Authentication.JsonReader")]
    public partial class DeviceObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(600U);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().Be("mockDeviceCode");
                traktDevice.UserCode.Should().Be("mockUserCode");
                traktDevice.VerificationUrl.Should().Be("mockUrl");
                traktDevice.ExpiresInSeconds.Should().Be(7200U);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);

                traktDevice.Should().NotBeNull();
                traktDevice.DeviceCode.Should().BeNull();
                traktDevice.UserCode.Should().BeNull();
                traktDevice.VerificationUrl.Should().BeNull();
                traktDevice.ExpiresInSeconds.Should().Be(0);
                traktDevice.IntervalInSeconds.Should().Be(0);
            }
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var objectJsonReader = new DeviceObjectJsonReader();
            ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(default(Stream));
            traktDevice.Should().BeNull();
        }

        [Fact]
        public async Task Test_DeviceObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var objectJsonReader = new DeviceObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                ITraktDevice traktDevice = await objectJsonReader.ReadObjectAsync(stream);
                traktDevice.Should().BeNull();
            }
        }
    }
}
