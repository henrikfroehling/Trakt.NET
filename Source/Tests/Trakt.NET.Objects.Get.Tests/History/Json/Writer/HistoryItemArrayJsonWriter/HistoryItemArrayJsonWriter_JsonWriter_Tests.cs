namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemArrayJsonWriter_Tests
    {
        [Fact]
        public void Test_HistoryItemArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<TraktHistoryItem>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktHistoryItems);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktHistoryItem> traktHistoryItems = new List<TraktHistoryItem>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktHistoryItem>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktHistoryItems);
                stringWriter.ToString().Should().Be("[]");
            }
        }
    }
}
