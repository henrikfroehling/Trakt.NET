namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktStatistics_Tests
    {
        [Fact]
        public void Test_TraktStatistics_Implements_ITraktStatistics_Interface()
        {
            typeof(TraktStatistics).GetInterfaces().Should().Contain(typeof(ITraktStatistics));
        }
    }
}
