namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktSharing_Tests
    {
        [Fact]
        public void Test_TraktSharing_Implements_ITraktSharing_Interface()
        {
            typeof(TraktSharing).GetInterfaces().Should().Contain(typeof(ITraktSharing));
        }
    }
}
