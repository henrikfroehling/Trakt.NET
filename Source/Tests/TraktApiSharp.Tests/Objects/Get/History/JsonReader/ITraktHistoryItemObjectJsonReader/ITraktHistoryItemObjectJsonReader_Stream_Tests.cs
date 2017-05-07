namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class ITraktHistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            var traktHistoryItem = await jsonReader.ReadObjectAsync(default(Stream));
            traktHistoryItem.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktHistoryItemObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new ITraktHistoryItemObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktHistoryItem = await jsonReader.ReadObjectAsync(stream);
                traktHistoryItem.Should().BeNull();
            }
        }
    }
}
