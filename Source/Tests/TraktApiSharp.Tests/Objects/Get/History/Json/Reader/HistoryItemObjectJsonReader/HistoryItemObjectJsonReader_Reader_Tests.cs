namespace TraktApiSharp.Tests.Objects.Get.History.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.History.Json.Reader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            var traktHistoryItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktHistoryItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktHistoryItem.Should().BeNull();
            }
        }
    }
}
