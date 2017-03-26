namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktMetadata_Tests
    {
        [Fact]
        public void Test_TraktMetadata_Implements_ITraktMetadata_Interface()
        {
            typeof(TraktMetadata).GetInterfaces().Should().Contain(typeof(ITraktMetadata));
        }
    }
}
