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
    public partial class UserMoviesStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            var userMoviesStatistics = await jsonReader.ReadObjectAsync(default(Stream));
            userMoviesStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserMoviesStatisticsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userMoviesStatistics = await jsonReader.ReadObjectAsync(stream);
                userMoviesStatistics.Should().BeNull();
            }
        }
    }
}
