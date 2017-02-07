namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
    public class TraktRequestHandler_Tests
    {
        [Fact]
        public void Test_TraktRequestHandler_Is_Not_Abstract()
        {
            typeof(TraktRequestHandler).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktRequestHandler_Is_Sealed()
        {
            typeof(TraktRequestHandler).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktRequestHandler_Implements_ITraktRequestHandler_Interface()
        {
            typeof(TraktRequestHandler).GetInterfaces().Should().Contain(typeof(ITraktRequestHandler));
        }
    }
}
