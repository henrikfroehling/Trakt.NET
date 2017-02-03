namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktPutRequestHandler_Tests
    {
        [Fact]
        public void Test_ITraktPutRequestHandler_Is_Interface()
        {
            typeof(ITraktPutRequestHandler).IsInterface.Should().BeTrue();
        }
    }
}
