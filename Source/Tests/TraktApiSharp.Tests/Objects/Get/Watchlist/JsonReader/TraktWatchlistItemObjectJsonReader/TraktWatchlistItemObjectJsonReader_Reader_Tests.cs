namespace TraktApiSharp.Tests.Objects.Get.Watchlist.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Watchlist.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watchlist.JsonReader")]
    public partial class TraktWatchlistItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktWatchlistItemObjectJsonReader();

            var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktWatchlistItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktWatchlistItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchlistItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktWatchlistItem.Should().BeNull();
            }
        }
    }
}
