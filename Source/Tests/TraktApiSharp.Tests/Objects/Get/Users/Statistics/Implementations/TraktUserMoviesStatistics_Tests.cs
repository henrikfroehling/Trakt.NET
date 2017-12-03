namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using TraktApiSharp.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserMoviesStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserMoviesStatistics_Default_Constructor()
        {
            var userMoviesStatistics = new TraktUserMoviesStatistics();

            userMoviesStatistics.Plays.Should().BeNull();
            userMoviesStatistics.Watched.Should().BeNull();
            userMoviesStatistics.Minutes.Should().BeNull();
            userMoviesStatistics.Collected.Should().BeNull();
            userMoviesStatistics.Ratings.Should().BeNull();
            userMoviesStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserMoviesStatistics_From_Json()
        {
            var jsonReader = new UserMoviesStatisticsObjectJsonReader();
            var userMoviesStatistics = await jsonReader.ReadObjectAsync(JSON) as TraktUserMoviesStatistics;

            userMoviesStatistics.Should().NotBeNull();
            userMoviesStatistics.Plays.Should().Be(552);
            userMoviesStatistics.Watched.Should().Be(534);
            userMoviesStatistics.Minutes.Should().Be(17330);
            userMoviesStatistics.Collected.Should().Be(117);
            userMoviesStatistics.Ratings.Should().Be(64);
            userMoviesStatistics.Comments.Should().Be(14);
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
