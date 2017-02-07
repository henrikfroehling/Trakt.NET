namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktBodylessPostRequest_Tests
    {
        [Fact]
        public void Test_ITraktBodylessPostRequest_Is_Interface()
        {
            typeof(ITraktBodylessPostRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktBodylessPostRequest_Inherits_ITraktRequest_Interface()
        {
            typeof(ITraktBodylessPostRequest).GetInterfaces().Should().Contain(typeof(ITraktRequest));
        }
    }
}
