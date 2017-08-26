namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
    public class IPutRequestHandler_Tests
    {
        [Fact]
        public void Test_IPutRequestHandler_Is_Interface()
        {
            typeof(IPutRequestHandler).IsInterface.Should().BeTrue();
        }
    }
}
