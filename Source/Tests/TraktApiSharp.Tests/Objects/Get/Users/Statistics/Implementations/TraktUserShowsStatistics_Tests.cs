namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using TraktApiSharp.Objects.Get.Users.Statistics.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserShowsStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserShowsStatistics_Implements_ITraktUserShowsStatistics_Interface()
        {
            typeof(TraktUserShowsStatistics).GetInterfaces().Should().Contain(typeof(ITraktUserShowsStatistics));
        }

        [Fact]
        public void Test_TraktUserShowsStatistics_Default_Constructor()
        {
            var userShowsStatistics = new TraktUserShowsStatistics();

            userShowsStatistics.Watched.Should().BeNull();
            userShowsStatistics.Collected.Should().BeNull();
            userShowsStatistics.Ratings.Should().BeNull();
            userShowsStatistics.Comments.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserShowsStatistics_From_Json()
        {
            var jsonReader = new TraktUserShowsStatisticsObjectJsonReader();
            var userShowsStatistics = await jsonReader.ReadObjectAsync(JSON) as TraktUserShowsStatistics;

            userShowsStatistics.Should().NotBeNull();
            userShowsStatistics.Watched.Should().Be(534);
            userShowsStatistics.Collected.Should().Be(117);
            userShowsStatistics.Ratings.Should().Be(64);
            userShowsStatistics.Comments.Should().Be(14);
        }

        private const string JSON =
            @"{
                ""watched"": 534,
                ""collected"": 117,
                ""ratings"": 64,
                ""comments"": 14
              }";
    }
}
