﻿namespace TraktNet.Objects.Tests.Get.Watchlist.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watchlist.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktWatchlistItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchlistItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new WatchlistItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktWatchlistItem.Should().BeNull();
            }
        }
    }
}
