namespace TraktApiSharp.Tests.Objects.Get.Watchlist.Json
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Watchlist.Json;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktWatchlistItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);
                traktWatchlistItem.Should().BeNull();
            }
        }
    }
}
