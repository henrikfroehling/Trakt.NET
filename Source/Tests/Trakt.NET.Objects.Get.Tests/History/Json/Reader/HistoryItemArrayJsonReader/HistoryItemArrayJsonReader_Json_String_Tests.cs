namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonReader")]
    public partial class HistoryItemArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();
            var traktHistoryItems = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktHistoryItems.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();
            Func<Task<IEnumerable<ITraktHistoryItem>>> traktHistoryItems = () => jsonReader.ReadArrayAsync(default(string));
            await traktHistoryItems.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktHistoryItem>();
            var traktHistoryItems = await jsonReader.ReadArrayAsync(string.Empty);
            traktHistoryItems.Should().BeNull();
        }
    }
}
