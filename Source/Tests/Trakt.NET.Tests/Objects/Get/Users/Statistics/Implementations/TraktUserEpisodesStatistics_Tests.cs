namespace TraktNet.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserEpisodesStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserEpisodesStatistics_Default_Constructor()
        {
            var userEpisodesStatistics = new TraktUserEpisodesStatistics();

            userEpisodesStatistics.Plays.Should().BeNull();
            userEpisodesStatistics.Watched.Should().BeNull();
            userEpisodesStatistics.Minutes.Should().BeNull();
            userEpisodesStatistics.Collected.Should().BeNull();
            userEpisodesStatistics.Ratings.Should().BeNull();
            userEpisodesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserEpisodesStatistics_From_Json()
        {
            var jsonReader = new UserEpisodesStatisticsObjectJsonReader();
            var userEpisodesStatistics = await jsonReader.ReadObjectAsync(JSON) as TraktUserEpisodesStatistics;

            userEpisodesStatistics.Should().NotBeNull();
            userEpisodesStatistics.Plays.Should().Be(552);
            userEpisodesStatistics.Watched.Should().Be(534);
            userEpisodesStatistics.Minutes.Should().Be(17330);
            userEpisodesStatistics.Collected.Should().Be(117);
            userEpisodesStatistics.Ratings.Should().Be(64);
            userEpisodesStatistics.Comments.Should().Be(14);
        }

        private const string JSON =
            @"{
                ""plays"": 552,
                ""watched"": 534,
                ""minutes"": 17330,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";
    }
}
