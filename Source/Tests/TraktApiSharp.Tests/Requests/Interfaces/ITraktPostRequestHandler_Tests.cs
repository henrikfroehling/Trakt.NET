namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktPostRequestHandler_Tests
    {
        [Fact]
        public void Test_ITraktPostRequestHandler_Is_Interface()
        {
            typeof(ITraktPostRequestHandler).IsInterface.Should().BeTrue();
        }
    }
}
