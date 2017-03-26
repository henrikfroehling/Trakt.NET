namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktGenre_Tests
    {
        [Fact]
        public void Test_TraktGenre_Implements_ITraktGenre_Interface()
        {
            typeof(TraktGenre).GetInterfaces().Should().Contain(typeof(ITraktGenre));
        }
    }
}
