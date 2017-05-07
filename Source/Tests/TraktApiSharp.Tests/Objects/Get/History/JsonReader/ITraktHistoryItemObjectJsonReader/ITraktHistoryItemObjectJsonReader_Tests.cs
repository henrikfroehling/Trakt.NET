namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class ITraktHistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktHistoryItemObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktHistoryItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktHistoryItem>));
        }
    }
}
