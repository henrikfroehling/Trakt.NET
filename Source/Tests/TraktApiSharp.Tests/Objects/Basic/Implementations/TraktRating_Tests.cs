namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktRating_Tests
    {
        [Fact]
        public void Test_TraktRating_Implements_ITraktRating_Interface()
        {
            typeof(TraktRating).GetInterfaces().Should().Contain(typeof(ITraktRating));
        }
    }
}
