namespace TraktNet.Objects.Get.Tests.Users.Statistics.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Statistics;
    using TraktNet.Objects.Get.Users.Statistics.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Statistics.Implementations")]
    public class TraktUserNetworkStatistics_Tests
    {
        [Fact]
        public void Test_TraktUserNetworkStatistics_Default_Constructor()
        {
            var userNetworkStatistics = new TraktUserNetworkStatistics();

            userNetworkStatistics.Friends.Should().BeNull();
            userNetworkStatistics.Followers.Should().BeNull();
            userNetworkStatistics.Following.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserNetworkStatistics_From_Json()
        {
            var jsonReader = new UserNetworkStatisticsObjectJsonReader();
            var userNetworkStatistics = await jsonReader.ReadObjectAsync(JSON) as TraktUserNetworkStatistics;

            userNetworkStatistics.Should().NotBeNull();
            userNetworkStatistics.Friends.Should().Be(1);
            userNetworkStatistics.Followers.Should().Be(4);
            userNetworkStatistics.Following.Should().Be(11);
        }

        private const string JSON =
            @"{
                ""friends"": 1,
                ""followers"": 4,
                ""following"": 11
              }";
    }
}
