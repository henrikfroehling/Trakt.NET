namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCastAndCrew_Tests
    {
        [Fact]
        public void Test_TraktCastAndCrew_Implements_ITraktCastAndCrew_Interface()
        {
            typeof(TraktCastAndCrew).GetInterfaces().Should().Contain(typeof(ITraktCastAndCrew));
        }
    }
}
