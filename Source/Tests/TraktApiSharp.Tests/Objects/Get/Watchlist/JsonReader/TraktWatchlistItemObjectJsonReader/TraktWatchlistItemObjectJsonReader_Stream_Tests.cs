namespace TraktApiSharp.Tests.Objects.Get.Watchlist.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Watchlist.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class TraktWatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktWatchlistItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktWatchlistItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktWatchlistItem = await jsonReader.ReadObjectAsync(stream);
                traktWatchlistItem.Should().BeNull();
            }
        }
    }
}
