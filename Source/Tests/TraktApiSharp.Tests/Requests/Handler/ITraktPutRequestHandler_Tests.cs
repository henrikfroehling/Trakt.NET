namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Handler;
    using Xunit;

    [Category("Requests.Handler")]
    public class ITraktPutRequestHandler_Tests
    {
        [Fact]
        public void Test_ITraktPutRequestHandler_Is_Interface()
        {
            typeof(ITraktPutRequestHandler).IsInterface.Should().BeTrue();
        }
    }
}
