namespace TraktNet.Objects.Get.Tests.Users.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Implementations")]
    public class TraktUserLimits_Tests
    {
        [Fact]
        public void Test_TraktUserLimits_Default_Constructor()
        {
            var userLimits = new TraktUserLimits();

            userLimits.List.Should().BeNull();
            userLimits.Watchlist.Should().BeNull();
            userLimits.Recommendations.Should().BeNull();
            userLimits.Favorites.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLimits_From_Json()
        {
            var jsonReader = new UserLimitsObjectJsonReader();
            var userLimits = await jsonReader.ReadObjectAsync(JSON) as TraktUserLimits;

            userLimits.Should().NotBeNull();

            userLimits.List.Should().NotBeNull();
            userLimits.List.Count.Should().Be(9999);
            userLimits.List.ItemCount.Should().Be(10000);

            userLimits.Watchlist.Should().NotBeNull();
            userLimits.Watchlist.ItemCount.Should().Be(10000);

            userLimits.Recommendations.Should().NotBeNull();
            userLimits.Recommendations.ItemCount.Should().Be(50);

            userLimits.Favorites.Should().NotBeNull();
            userLimits.Favorites.ItemCount.Should().Be(50);
        }

        private const string JSON =
            @"{
                ""list"": {
                  ""count"": 9999,
                  ""item_count"": 10000
                },
                ""watchlist"": {
                  ""item_count"": 10000
                },
                ""favorites"": {
                  ""item_count"": 50
                },
                ""recommendations"": {
                  ""item_count"": 50
                }
              }";
    }
}
