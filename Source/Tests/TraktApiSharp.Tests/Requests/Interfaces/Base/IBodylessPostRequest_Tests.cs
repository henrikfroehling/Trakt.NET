namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IBodylessPostRequest_Tests
    {
        [Fact]
        public void Test_IBodylessPostRequest_Is_Interface()
        {
            typeof(IBodylessPostRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IBodylessPostRequest_Inherits_IRequest_Interface()
        {
            typeof(IBodylessPostRequest).GetInterfaces().Should().Contain(typeof(IRequest));
        }
    }
}
