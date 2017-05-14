namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class TraktHistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktHistoryItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktHistoryItemObjectJsonReader();

            var traktHistoryItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktHistoryItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktHistoryItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);
                traktHistoryItem.Should().BeNull();
            }
        }
    }
}
