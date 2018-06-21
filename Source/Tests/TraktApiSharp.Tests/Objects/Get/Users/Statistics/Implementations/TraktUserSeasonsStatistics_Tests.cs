namespace TraktNet.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserSeasonsStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserSeasonsStatistics_Default_Constructor()
        {
            var userSeasonsStatistics = new TraktUserSeasonsStatistics();

            userSeasonsStatistics.Ratings.Should().BeNull();
            userSeasonsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserSeasonsStatistics_From_Json()
        {
            var jsonReader = new UserSeasonsStatisticsObjectJsonReader();
            var userSeasonsStatistics = await jsonReader.ReadObjectAsync(JSON) as TraktUserSeasonsStatistics;

            userSeasonsStatistics.Should().NotBeNull();
            userSeasonsStatistics.Ratings.Should().Be(6);
            userSeasonsStatistics.Comments.Should().Be(1);
        }

        private const string JSON =
            @"{
                ""ratings"": 6,
                ""comments"": 1
              }";
    }
}
