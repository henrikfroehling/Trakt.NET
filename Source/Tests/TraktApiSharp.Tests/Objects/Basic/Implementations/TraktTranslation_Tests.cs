namespace TraktApiSharp.Tests.Objects.Basic.Implementations
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Basic.Implementations;
    using Xunit;

    [Category("Objects.Basic.Implementations")]
    public class TraktTranslation_Tests
    {
        [Fact]
        public void Test_TraktTranslation_Implements_ITraktTranslation_Interface()
        {
            typeof(TraktTranslation).GetInterfaces().Should().Contain(typeof(ITraktTranslation));
        }
    }
}
