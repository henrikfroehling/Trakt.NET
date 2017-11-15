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
    public partial class UserSeasonsStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userSeasonsStatistics = await jsonReader.ReadObjectAsync(stream);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().Be(6);
                userSeasonsStatistics.Comments.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userSeasonsStatistics = await jsonReader.ReadObjectAsync(stream);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().BeNull();
                userSeasonsStatistics.Comments.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userSeasonsStatistics = await jsonReader.ReadObjectAsync(stream);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().Be(6);
                userSeasonsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userSeasonsStatistics = await jsonReader.ReadObjectAsync(stream);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().BeNull();
                userSeasonsStatistics.Comments.Should().Be(1);
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userSeasonsStatistics = await jsonReader.ReadObjectAsync(stream);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().Be(6);
                userSeasonsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userSeasonsStatistics = await jsonReader.ReadObjectAsync(stream);

                userSeasonsStatistics.Should().NotBeNull();
                userSeasonsStatistics.Ratings.Should().BeNull();
                userSeasonsStatistics.Comments.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(default(Stream));
            userSeasonsStatistics.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSeasonsStatisticsObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userSeasonsStatistics = await jsonReader.ReadObjectAsync(stream);
                userSeasonsStatistics.Should().BeNull();
            }
        }
    }
}
