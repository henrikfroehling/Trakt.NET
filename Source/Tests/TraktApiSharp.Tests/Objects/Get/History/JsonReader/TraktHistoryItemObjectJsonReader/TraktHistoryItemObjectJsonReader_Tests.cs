namespace TraktApiSharp.Tests.Objects.Get.History.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Get.History;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.JsonReader")]
    public partial class TraktHistoryItemObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktHistoryItemObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktHistoryItemObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktHistoryItem>));
        }
    }
}
