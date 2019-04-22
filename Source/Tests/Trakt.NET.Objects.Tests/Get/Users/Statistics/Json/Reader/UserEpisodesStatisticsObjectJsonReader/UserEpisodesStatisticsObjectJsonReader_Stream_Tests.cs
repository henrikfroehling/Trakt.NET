namespace TraktNet.Objects.Tests.Get.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.JsonReader")]
    public partial class UserEpisodesStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            var userEpisodesStatistics = await jsonReader.ReadObjectAsync(default(Stream));
            userEpisodesStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserEpisodesStatisticsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userEpisodesStatistics = await jsonReader.ReadObjectAsync(stream);
                userEpisodesStatistics.Should().BeNull();
            }
        }
    }
}
