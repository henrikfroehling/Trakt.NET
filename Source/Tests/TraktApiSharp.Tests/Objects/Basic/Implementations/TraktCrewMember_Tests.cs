namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCrewMember_Tests
    {
        [Fact]
        public void Test_TraktCrewMember_Implements_ITraktCrewMember_Interface()
        {
            typeof(TraktCrewMember).GetInterfaces().Should().Contain(typeof(ITraktCrewMember));
        }
    }
}
