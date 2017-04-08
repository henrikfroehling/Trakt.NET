namespace TraktApiSharp.Tests.Objects.Basic.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class ITraktStatisticsObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktStatisticsObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktStatisticsObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktStatistics>));
        }
    }
}
