namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Get.History.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            Func<Task<ITraktHistoryItem>> traktHistoryItem = () => jsonReader.ReadObjectAsync(default(string));
            await traktHistoryItem.Should().ThrowAsync<ArgumentNullException>();
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
