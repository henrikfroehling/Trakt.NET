namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserShowsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().Be(14);
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().Be(534);
                userShowsStatistics.Collected.Should().Be(117);
                userShowsStatistics.Ratings.Should().Be(64);
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);

                userShowsStatistics.Should().NotBeNull();
                userShowsStatistics.Watched.Should().BeNull();
                userShowsStatistics.Collected.Should().BeNull();
                userShowsStatistics.Ratings.Should().BeNull();
                userShowsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            var userShowsStatistics = await jsonReader.ReadObjectAsync(default(Stream));
            userShowsStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserShowsStatisticsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserShowsStatisticsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userShowsStatistics = await jsonReader.ReadObjectAsync(stream);
                userShowsStatistics.Should().BeNull();
            }
        }
    }
}
