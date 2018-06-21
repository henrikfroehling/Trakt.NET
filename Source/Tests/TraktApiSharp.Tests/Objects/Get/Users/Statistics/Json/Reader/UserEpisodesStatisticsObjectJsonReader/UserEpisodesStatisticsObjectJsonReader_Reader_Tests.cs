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
    public partial class UserEpisodesStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().BeNull();
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().BeNull();
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().BeNull();
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().BeNull();
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().BeNull();
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().BeNull();
                userEpisodesStatistics.Minutes.Should().BeNull();
                userEpisodesStatistics.Collected.Should().BeNull();
                userEpisodesStatistics.Ratings.Should().BeNull();
                userEpisodesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().BeNull();
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().BeNull();
                userEpisodesStatistics.Collected.Should().BeNull();
                userEpisodesStatistics.Ratings.Should().BeNull();
                userEpisodesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().BeNull();
                userEpisodesStatistics.Watched.Should().BeNull();
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().BeNull();
                userEpisodesStatistics.Ratings.Should().BeNull();
                userEpisodesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().BeNull();
                userEpisodesStatistics.Watched.Should().BeNull();
                userEpisodesStatistics.Minutes.Should().BeNull();
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().BeNull();
                userEpisodesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().BeNull();
                userEpisodesStatistics.Watched.Should().BeNull();
                userEpisodesStatistics.Minutes.Should().BeNull();
                userEpisodesStatistics.Collected.Should().BeNull();
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().BeNull();
                userEpisodesStatistics.Watched.Should().BeNull();
                userEpisodesStatistics.Minutes.Should().BeNull();
                userEpisodesStatistics.Collected.Should().BeNull();
                userEpisodesStatistics.Ratings.Should().BeNull();
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().BeNull();
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().BeNull();
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().BeNull();
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().BeNull();
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().BeNull();
                userEpisodesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().Be(552);
                userEpisodesStatistics.Watched.Should().Be(534);
                userEpisodesStatistics.Minutes.Should().Be(17330);
                userEpisodesStatistics.Collected.Should().Be(117);
                userEpisodesStatistics.Ratings.Should().Be(64);
                userEpisodesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userEpisodesStatistics.Should().NotBeNull();
                userEpisodesStatistics.Plays.Should().BeNull();
                userEpisodesStatistics.Watched.Should().BeNull();
                userEpisodesStatistics.Minutes.Should().BeNull();
                userEpisodesStatistics.Collected.Should().BeNull();
                userEpisodesStatistics.Ratings.Should().BeNull();
                userEpisodesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userEpisodesStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userEpisodesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);
                userEpisodesStatistics.Should().BeNull();
            }
        }
    }
}
