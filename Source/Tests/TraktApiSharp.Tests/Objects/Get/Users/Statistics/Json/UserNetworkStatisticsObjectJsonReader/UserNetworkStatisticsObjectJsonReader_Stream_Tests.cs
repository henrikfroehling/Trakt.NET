namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics.Json;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserNetworkStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(default(Stream));
            userNetworkStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userNetworkStatistics = await jsonReader.ReadObjectAsync(stream);
                userNetworkStatistics.Should().BeNull();
            }
        }
    }
}
