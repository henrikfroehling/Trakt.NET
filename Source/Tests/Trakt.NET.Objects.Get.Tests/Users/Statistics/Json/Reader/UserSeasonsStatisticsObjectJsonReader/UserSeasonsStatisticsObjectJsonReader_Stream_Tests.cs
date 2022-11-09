namespace TraktNet.Objects.Get.Tests.Users.Statistics.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Statistics.JsonReader")]
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
            Func<Task<ITraktUserSeasonsStatistics>> userSeasonsStatistics = () => jsonReader.ReadObjectAsync(default(Stream));
            await userSeasonsStatistics.Should().ThrowAsync<ArgumentNullException>();
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
