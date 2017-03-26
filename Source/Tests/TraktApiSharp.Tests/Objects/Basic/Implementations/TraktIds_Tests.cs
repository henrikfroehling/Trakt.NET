namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktIds_Tests
    {
        [Fact]
        public void Test_TraktIds_Implements_ITraktIds_Interface()
        {
            typeof(TraktIds).GetInterfaces().Should().Contain(typeof(ITraktIds));
        }
    }
}
