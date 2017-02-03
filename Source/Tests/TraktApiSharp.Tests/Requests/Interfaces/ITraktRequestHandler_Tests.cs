namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktRequestHandler_Tests
    {
        [Fact]
        public void Test_ITraktRequestHandler_Is_Interface()
        {
            typeof(ITraktRequestHandler).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktRequestHandler_Inherits_ITraktPostRequestHandler_Interface()
        {
            typeof(ITraktRequestHandler).GetInterfaces().Should().Contain(typeof(ITraktPostRequestHandler));
        }

        [Fact]
        public void Test_ITraktRequestHandler_Inherits_ITraktPutRequestHandler_Interface()
        {
            typeof(ITraktRequestHandler).GetInterfaces().Should().Contain(typeof(ITraktPutRequestHandler));
        }
    }
}
