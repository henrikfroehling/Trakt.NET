namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
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
            typeof(ITraktRequestHandler).GetInterfaces().Should().Contain(typeof(IPostRequestHandler));
        }

        [Fact]
        public void Test_ITraktRequestHandler_Inherits_ITraktPutRequestHandler_Interface()
        {
            typeof(ITraktRequestHandler).GetInterfaces().Should().Contain(typeof(IPutRequestHandler));
        }
    }
}
