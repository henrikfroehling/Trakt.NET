namespace TraktNet.Objects.Get.Tests.Users.Statistics.Implementations
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserRatingsStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserRatingsStatistics_Default_Constructor()
        {
            var userRatingsStatistics = new TraktUserRatingsStatistics();

            userRatingsStatistics.Total.Should().BeNull();
            userRatingsStatistics.Distribution.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserRatingsStatistics_From_Json()
        {
            var jsonReader = new UserRatingsStatisticsObjectJsonReader();
            var userRatingsStatistics = await jsonReader.ReadObjectAsync(JSON) as TraktUserRatingsStatistics;

            userRatingsStatistics.Should().NotBeNull();
            userRatingsStatistics.Total.Should().Be(9257);
            userRatingsStatistics.Distribution.Should().NotBeNull();
            userRatingsStatistics.Distribution.Should().NotBeEmpty();
            userRatingsStatistics.Distribution.Should().HaveCount(10);
            userRatingsStatistics.Distribution.Should().Contain(new Dictionary<string, int>
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
              }";
    }
}
