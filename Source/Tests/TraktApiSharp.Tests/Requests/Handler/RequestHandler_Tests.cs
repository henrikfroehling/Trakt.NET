namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
    public class RequestHandler_Tests
    {
        [Fact]
        public void Test_RequestHandler_Is_Not_Abstract()
        {
            typeof(RequestHandler).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_RequestHandler_Is_Sealed()
        {
            typeof(RequestHandler).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_RequestHandler_Implements_IRequestHandler_Interface()
        {
            typeof(RequestHandler).GetInterfaces().Should().Contain(typeof(IRequestHandler));
        }
    }
}
