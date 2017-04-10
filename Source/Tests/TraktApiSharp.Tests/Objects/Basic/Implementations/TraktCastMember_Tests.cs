namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktCastMember_Tests
    {
        [Fact]
        public void Test_TraktCastMember_Implements_ITraktCastMember_Interface()
        {
            typeof(TraktCastMember).GetInterfaces().Should().Contain(typeof(ITraktCastMember));
        }
    }
}
