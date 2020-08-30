namespace TraktNet.Objects.Get.Tests.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserMoviesStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().BeNull();
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().BeNull();
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().BeNull();
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().BeNull();
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().BeNull();
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().BeNull();
                userMoviesStatistics.Minutes.Should().BeNull();
                userMoviesStatistics.Collected.Should().BeNull();
                userMoviesStatistics.Ratings.Should().BeNull();
                userMoviesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().BeNull();
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().BeNull();
                userMoviesStatistics.Collected.Should().BeNull();
                userMoviesStatistics.Ratings.Should().BeNull();
                userMoviesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().BeNull();
                userMoviesStatistics.Watched.Should().BeNull();
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().BeNull();
                userMoviesStatistics.Ratings.Should().BeNull();
                userMoviesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().BeNull();
                userMoviesStatistics.Watched.Should().BeNull();
                userMoviesStatistics.Minutes.Should().BeNull();
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().BeNull();
                userMoviesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().BeNull();
                userMoviesStatistics.Watched.Should().BeNull();
                userMoviesStatistics.Minutes.Should().BeNull();
                userMoviesStatistics.Collected.Should().BeNull();
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().BeNull();
                userMoviesStatistics.Watched.Should().BeNull();
                userMoviesStatistics.Minutes.Should().BeNull();
                userMoviesStatistics.Collected.Should().BeNull();
                userMoviesStatistics.Ratings.Should().BeNull();
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().BeNull();
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().BeNull();
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().BeNull();
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().BeNull();
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().BeNull();
                userMoviesStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().Be(552);
                userMoviesStatistics.Watched.Should().Be(534);
                userMoviesStatistics.Minutes.Should().Be(17330);
                userMoviesStatistics.Collected.Should().Be(117);
                userMoviesStatistics.Ratings.Should().Be(64);
                userMoviesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userMoviesStatistics.Should().NotBeNull();
                userMoviesStatistics.Plays.Should().BeNull();
                userMoviesStatistics.Watched.Should().BeNull();
                userMoviesStatistics.Minutes.Should().BeNull();
                userMoviesStatistics.Collected.Should().BeNull();
                userMoviesStatistics.Ratings.Should().BeNull();
                userMoviesStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public void Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();
            Func<Task<ITraktUserMoviesStatistics>> userMoviesStatistics = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userMoviesStatistics.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userMoviesStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);
                userMoviesStatistics.Should().BeNull();
            }
        }
    }
}
