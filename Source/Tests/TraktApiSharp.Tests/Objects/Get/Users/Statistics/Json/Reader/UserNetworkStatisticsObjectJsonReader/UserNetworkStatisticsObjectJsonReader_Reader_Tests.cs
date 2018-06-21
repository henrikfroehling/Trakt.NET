namespace TraktNet.Tests.Objects.Get.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserNetworkStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().Be(11);
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().Be(1);
                userNetworkStatistics.Followers.Should().Be(4);
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userNetworkStatistics.Should().NotBeNull();
                userNetworkStatistics.Friends.Should().BeNull();
                userNetworkStatistics.Followers.Should().BeNull();
                userNetworkStatistics.Following.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userNetworkStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserNetworkStatisticsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userNetworkStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);
                userNetworkStatistics.Should().BeNull();
            }
        }
    }
}
