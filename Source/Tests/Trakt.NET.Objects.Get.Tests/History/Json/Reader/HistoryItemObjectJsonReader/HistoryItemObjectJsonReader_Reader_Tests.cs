namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Get.History.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new HistoryItemObjectJsonReader();
            Func<Task<ITraktHistoryItem>> traktHistoryItem = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktHistoryItem.Should().ThrowAsync<ArgumentNullException>();
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
