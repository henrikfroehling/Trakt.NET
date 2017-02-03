namespace TraktApiSharp.Tests.Requests
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests")]
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
