namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
    public class IRequestHandler_Tests
    {
        [Fact]
        public void Test_IRequestHandler_Is_Interface()
        {
            typeof(IRequestHandler).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IRequestHandler_Inherits_ITraktPostRequestHandler_Interface()
        {
            typeof(IRequestHandler).GetInterfaces().Should().Contain(typeof(IPostRequestHandler));
        }

        [Fact]
        public void Test_IRequestHandler_Inherits_ITraktPutRequestHandler_Interface()
        {
            typeof(IRequestHandler).GetInterfaces().Should().Contain(typeof(IPutRequestHandler));
        }
    }
}
