namespace TraktNet.Tests.Objects.Get.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserSeasonsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userSeasonsStatistics.Should().NotBeNull();
            userSeasonsStatistics.Ratings.Should().Be(6);
            userSeasonsStatistics.Comments.Should().Be(1);
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userSeasonsStatistics.Should().NotBeNull();
            userSeasonsStatistics.Ratings.Should().BeNull();
            userSeasonsStatistics.Comments.Should().Be(1);
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userSeasonsStatistics.Should().NotBeNull();
            userSeasonsStatistics.Ratings.Should().Be(6);
            userSeasonsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userSeasonsStatistics.Should().NotBeNull();
            userSeasonsStatistics.Ratings.Should().BeNull();
            userSeasonsStatistics.Comments.Should().Be(1);
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userSeasonsStatistics.Should().NotBeNull();
            userSeasonsStatistics.Ratings.Should().Be(6);
            userSeasonsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userSeasonsStatistics.Should().NotBeNull();
            userSeasonsStatistics.Ratings.Should().BeNull();
            userSeasonsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(default(string));
            userSeasonsStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(string.Empty);
            userSeasonsStatistics.Should().BeNull();
        }
    }
}
