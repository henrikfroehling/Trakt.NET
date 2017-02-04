namespace TraktApiSharp.Tests.Requests.Handler
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Handler;
    using TraktApiSharp.Tests.Traits;
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
