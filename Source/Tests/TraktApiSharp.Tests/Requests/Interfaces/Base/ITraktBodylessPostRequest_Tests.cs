namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
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
