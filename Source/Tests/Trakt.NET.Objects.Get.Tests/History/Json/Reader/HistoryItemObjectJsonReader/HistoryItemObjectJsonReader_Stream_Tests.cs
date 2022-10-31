namespace TraktNet.Objects.Get.Tests.History.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Get.History.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            Func<Task<ITraktHistoryItem>> traktHistoryItem = () => jsonReader.ReadObjectAsync(default(Stream));
            await traktHistoryItem.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_HistoryItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new HistoryItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);
                traktHistoryItem.Should().BeNull();
            }
        }
    }
}
