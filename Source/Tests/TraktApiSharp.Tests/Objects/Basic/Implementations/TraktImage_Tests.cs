namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktImage_Tests
    {
        [Fact]
        public void Test_TraktImage_Implements_ITraktImage_Interface()
        {
            typeof(TraktImage).GetInterfaces().Should().Contain(typeof(ITraktImage));
        }
    }
}
