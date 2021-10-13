namespace TraktNet.Objects.Get.Tests.Watchlist.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watchlist;
    using TraktNet.Objects.Get.Watchlist.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            Func<Task<ITraktWatchlistItem>> traktWatchlistItem = () => jsonReader.ReadObjectAsync(default(string));
            await traktWatchlistItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktWatchlistItem.Should().BeNull();
        }
    }
}
