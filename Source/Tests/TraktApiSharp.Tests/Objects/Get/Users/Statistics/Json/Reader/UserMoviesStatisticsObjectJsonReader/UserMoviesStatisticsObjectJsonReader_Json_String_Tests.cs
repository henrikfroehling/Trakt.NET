namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserMoviesStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().Be(14);
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(default(string));
            userMoviesStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(string.Empty);
            userMoviesStatistics.Should().BeNull();
        }
    }
}
