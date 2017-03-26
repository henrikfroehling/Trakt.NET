namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktComment_Tests
    {
        [Fact]
        public void Test_TraktComment_Implements_ITraktComment_Interface()
        {
            typeof(TraktComment).GetInterfaces().Should().Contain(typeof(ITraktComment));
        }
    }
}
