namespace TraktApiSharp.Tests.Objects.Get.History.Json
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.History.Json;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            var traktHistoryItem = await jsonReader.ReadObjectAsync(default(string));
            traktHistoryItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            var traktHistoryItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktHistoryItem.Should().BeNull();
        }
    }
}
