namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCrew_Tests
    {
        [Fact]
        public void Test_TraktCrew_Implements_ITraktCrew_Interface()
        {
            typeof(TraktCrew).GetInterfaces().Should().Contain(typeof(ITraktCrew));
        }
    }
}
