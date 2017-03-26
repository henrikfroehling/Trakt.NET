namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktError_Tests
    {
        [Fact]
        public void Test_TraktError_Implements_ITraktError_Interface()
        {
            typeof(TraktError).GetInterfaces().Should().Contain(typeof(ITraktError));
        }
    }
}
