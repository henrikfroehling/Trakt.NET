namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
    public class IPostRequestHandler_Tests
    {
        [Fact]
        public void Test_IPostRequestHandler_Is_Interface()
        {
            typeof(IPostRequestHandler).IsInterface.Should().BeTrue();
        }
    }
}
