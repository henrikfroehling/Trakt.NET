namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History.Json.Reader;
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
