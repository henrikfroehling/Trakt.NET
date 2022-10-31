namespace TraktNet.Objects.Get.Tests.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserShowsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().BeNull();
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().BeNull();
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().BeNull();
            userShowsStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().BeNull();
            userShowsStatistics.Ratings.Should().BeNull();
            userShowsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().BeNull();
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().BeNull();
            userShowsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().BeNull();
            userShowsStatistics.Collected.Should().BeNull();
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().BeNull();
            userShowsStatistics.Collected.Should().BeNull();
            userShowsStatistics.Ratings.Should().BeNull();
            userShowsStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().BeNull();
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().BeNull();
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().BeNull();
            userShowsStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().BeNull();
            userShowsStatistics.Collected.Should().BeNull();
            userShowsStatistics.Ratings.Should().BeNull();
            userShowsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();
            Func<Task<ITraktUserShowsStatistics>> userShowsStatistics = () => jsonReader.ReadObjectAsync(default(string));
            await userShowsStatistics.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(string.Empty);
            userShowsStatistics.Should().BeNull();
        }
    }
}
