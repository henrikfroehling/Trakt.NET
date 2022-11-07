namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_WriteArray_Array_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_WriteArray_Array_Empty()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<TraktHistoryItem>();
            var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
            string json = await traktJsonWriter.WriteArrayAsync(traktHistoryItems);
            json.Should().Be("[]");
        }
    }
}
