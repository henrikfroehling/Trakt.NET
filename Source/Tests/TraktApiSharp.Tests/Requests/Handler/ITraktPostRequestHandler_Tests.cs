namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
    public class ITraktPostRequestHandler_Tests
    {
        [Fact]
        public void Test_ITraktPostRequestHandler_Is_Interface()
        {
            typeof(ITraktPostRequestHandler).IsInterface.Should().BeTrue();
        }
    }
}
