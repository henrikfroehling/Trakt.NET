namespace TraktNet.Objects.Tests.Get.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserNetworkStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().Be(1);
            userNetworkStatistics.Followers.Should().Be(4);
            userNetworkStatistics.Following.Should().Be(11);
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().BeNull();
            userNetworkStatistics.Followers.Should().Be(4);
            userNetworkStatistics.Following.Should().Be(11);
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().Be(1);
            userNetworkStatistics.Followers.Should().BeNull();
            userNetworkStatistics.Following.Should().Be(11);
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().Be(1);
            userNetworkStatistics.Followers.Should().Be(4);
            userNetworkStatistics.Following.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().Be(1);
            userNetworkStatistics.Followers.Should().BeNull();
            userNetworkStatistics.Following.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().BeNull();
            userNetworkStatistics.Followers.Should().Be(4);
            userNetworkStatistics.Following.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().BeNull();
            userNetworkStatistics.Followers.Should().BeNull();
            userNetworkStatistics.Following.Should().Be(11);
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().BeNull();
            userNetworkStatistics.Followers.Should().Be(4);
            userNetworkStatistics.Following.Should().Be(11);
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().Be(1);
            userNetworkStatistics.Followers.Should().BeNull();
            userNetworkStatistics.Following.Should().Be(11);
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().Be(1);
            userNetworkStatistics.Followers.Should().Be(4);
            userNetworkStatistics.Following.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().BeNull();
            userNetworkStatistics.Followers.Should().BeNull();
            userNetworkStatistics.Following.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(default(string));
            userNetworkStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserNetworkStatisticsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();

            var userNetworkStatistics = await jsonReader.ReadObjectAsync(string.Empty);
            userNetworkStatistics.Should().BeNull();
        }
    }
}
