namespace TraktApiSharp.Tests.Objects.Get.Users.Statistics.Implementations
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Statistics.Implementations;
    using TraktApiSharp.Objects.Get.Users.Statistics.Json;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserStatistics_Default_Constructor()
        {
            var userStatistics = new TraktUserStatistics();

            userStatistics.Movies.Should().BeNull();
            userStatistics.Shows.Should().BeNull();
            userStatistics.Seasons.Should().BeNull();
            userStatistics.Episodes.Should().BeNull();
            userStatistics.Network.Should().BeNull();
            userStatistics.Ratings.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserStatistics_From_Json()
        {
            var jsonReader = new UserStatisticsObjectJsonReader();
            var userStatistics = await jsonReader.ReadObjectAsync(JSON) as TraktUserStatistics;

            userStatistics.Should().NotBeNull();

            userStatistics.Movies.Should().NotBeNull();
            userStatistics.Movies.Plays.Should().Be(552);
            userStatistics.Movies.Watched.Should().Be(534);
            userStatistics.Movies.Minutes.Should().Be(17330);
            userStatistics.Movies.Collected.Should().Be(117);
            userStatistics.Movies.Ratings.Should().Be(64);
            userStatistics.Movies.Comments.Should().Be(14);

            userStatistics.Shows.Should().NotBeNull();
            userStatistics.Shows.Watched.Should().Be(534);
            userStatistics.Shows.Collected.Should().Be(117);
            userStatistics.Shows.Ratings.Should().Be(64);
            userStatistics.Shows.Comments.Should().Be(14);

            userStatistics.Seasons.Should().NotBeNull();
            userStatistics.Seasons.Ratings.Should().Be(6);
            userStatistics.Seasons.Comments.Should().Be(1);

            userStatistics.Episodes.Should().NotBeNull();
            userStatistics.Episodes.Plays.Should().Be(552);
            userStatistics.Episodes.Watched.Should().Be(534);
            userStatistics.Episodes.Minutes.Should().Be(17330);
            userStatistics.Episodes.Collected.Should().Be(117);
            userStatistics.Episodes.Ratings.Should().Be(64);
            userStatistics.Episodes.Comments.Should().Be(14);

            userStatistics.Network.Should().NotBeNull();
            userStatistics.Network.Friends.Should().Be(1);
            userStatistics.Network.Followers.Should().Be(4);
            userStatistics.Network.Following.Should().Be(11);

            userStatistics.Ratings.Should().NotBeNull();
            userStatistics.Ratings.Total.Should().Be(9257);
            userStatistics.Ratings.Distribution.Should().NotBeNull();
            userStatistics.Ratings.Distribution.Should().NotBeEmpty();
            userStatistics.Ratings.Distribution.Should().HaveCount(10);
            userStatistics.Ratings.Distribution.Should().Contain(new Dictionary<string, int>
            {
                ["1"] = 78,
                ["2"] = 45,
                ["3"] = 55,
                ["4"] = 96,
                ["5"] = 183,
                ["6"] = 545,
                ["7"] = 1361,
                ["8"] = 2259,
                ["9"] = 1772,
                ["10"] = 2863
            });
        }

        private const string JSON =
            @"{
                ""movies"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""shows"": {
                  ""watched"": 534,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""seasons"": {
                  ""ratings"": 6,
                  ""comments"": 1
                },
                ""episodes"": {
                  ""plays"": 552,
                  ""watched"": 534,
                  ""minutes"": 17330,
                  ""collected"": 117,
                  ""ratings"": 64,
                  ""comments"": 14
                },
                ""network"": {
                  ""friends"": 1,
                  ""followers"": 4,
                  ""following"": 11
                },
                ""ratings"": {
                  ""total"": 9257,
                  ""distribution"": {
                    ""1"": 78,
                    ""2"": 45,
                    ""3"": 55,
                    ""4"": 96,
                    ""5"": 183,
                    ""6"": 545,
                    ""7"": 1361,
                    ""8"": 2259,
                    ""9"": 1772,
                    ""10"": 2863
                  }
                }
              }";
    }
}
