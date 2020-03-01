namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History.Json.Reader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new HistoryItemArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new HistoryItemArrayJsonReader();
            var traktHistoryItems = await traktJsonReader.ReadArrayAsync(default(Stream));
            traktHistoryItems.Should().BeNull();
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new HistoryItemArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktHistoryItems = await traktJsonReader.ReadArrayAsync(stream);
                traktHistoryItems.Should().BeNull();
            }
        }
    }
}
