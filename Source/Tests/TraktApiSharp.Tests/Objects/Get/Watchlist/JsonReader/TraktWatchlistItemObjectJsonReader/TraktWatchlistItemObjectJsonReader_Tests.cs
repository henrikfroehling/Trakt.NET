namespace TraktApiSharp.Tests.Objects.Get.Watchlist.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Objects.Get.Watchlist.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class TraktWatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktWatchlistItemObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktWatchlistItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktWatchlistItem>));
        }
    }
}
