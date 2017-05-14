namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class TraktHistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktHistoryItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktHistoryItemObjectJsonReader();

            var traktHistoryItem = await jsonReader.ReadObjectAsync(default(string));
            traktHistoryItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItemObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktHistoryItemObjectJsonReader();

            var traktHistoryItem = await jsonReader.ReadObjectAsync(string.Empty);
            traktHistoryItem.Should().BeNull();
        }
    }
}
