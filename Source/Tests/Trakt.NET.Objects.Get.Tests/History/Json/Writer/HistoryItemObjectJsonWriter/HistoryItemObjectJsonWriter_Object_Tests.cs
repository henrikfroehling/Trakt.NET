namespace TraktNet.Objects.Get.Tests.History.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.History;
    using TraktNet.Objects.Get.History.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Get.History.JsonWriter")]
    public partial class HistoryItemObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_HistoryItemObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new HistoryItemObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktHistoryItem));
            await action.Should().ThrowAsync<ArgumentNullException>();
        }
    }
}
