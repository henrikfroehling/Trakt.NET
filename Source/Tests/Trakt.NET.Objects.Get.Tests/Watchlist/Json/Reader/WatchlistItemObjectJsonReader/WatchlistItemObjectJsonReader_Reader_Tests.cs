namespace TraktNet.Objects.Get.Tests.Watchlist.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watchlist;
    using TraktNet.Objects.Get.Watchlist.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();
            Func<Task<ITraktWatchlistItem>> traktWatchlistItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktWatchlistItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktWatchlistItem.Should().BeNull();
        }
    }
}
