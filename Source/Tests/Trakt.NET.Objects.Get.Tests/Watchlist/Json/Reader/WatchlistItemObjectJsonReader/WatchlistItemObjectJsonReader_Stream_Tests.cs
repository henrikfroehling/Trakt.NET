namespace TraktNet.Objects.Get.Tests.Watchlist.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watchlist;
    using TraktNet.Objects.Get.Watchlist.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class WatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_WatchlistItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            Func<Task<ITraktWatchlistItem>> traktWatchlistItem = () => jsonReader.ReadObjectAsync(default(Stream));
            traktWatchlistItem.Should().Throw<ArgumentNullException>();
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
