namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserShowsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userShowsStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userShowsStatistics = await traktJsonReader.ReadObjectAsync(jsonReader);
                userShowsStatistics.Should().BeNull();
            }
        }
    }
}
