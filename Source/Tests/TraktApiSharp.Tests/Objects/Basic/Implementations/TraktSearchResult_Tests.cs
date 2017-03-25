namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktSearchResult_Tests
    {
        [Fact]
        public void Test_TraktSearchResult_Implements_ITraktSearchResult_Interface()
        {
            typeof(TraktSearchResult).GetInterfaces().Should().Contain(typeof(ITraktSearchResult));
        }
    }
}
