namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class ITraktHistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            var traktHistoryItem = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktHistoryItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktHistoryItem = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktHistoryItem.Should().BeNull();
            }
        }
    }
}
