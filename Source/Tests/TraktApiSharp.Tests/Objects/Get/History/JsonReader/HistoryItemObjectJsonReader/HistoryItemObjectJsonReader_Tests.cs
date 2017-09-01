namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class HistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_HistoryItemObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(HistoryItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktHistoryItem>));
        }
    }
}
