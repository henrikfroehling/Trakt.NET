namespace TraktApiSharp.Tests.Objects.Get.Watchlist.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Objects.Get.Watchlist.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_WatchlistItemObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(WatchlistItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktWatchlistItem>));
        }
    }
}
