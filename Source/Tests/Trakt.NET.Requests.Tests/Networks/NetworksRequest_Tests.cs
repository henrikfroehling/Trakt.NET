namespace TraktNet.Requests.Tests.Networks
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Networks;
    using Xunit;

    [TestCategory("Requests.Networks")]
    public class NetworksRequest_Tests
    {
        [Fact]
        public void Test_NetworksRequest_Has_AuthorizationRequirement_NotRequired()
        {
            var request = new NetworksRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_NetworksRequest_Has_Valid_UriTemplate()
        {
            var request = new NetworksRequest();
            request.UriTemplate.Should().Be("networks");
        }

        [Fact]
        public void Test_NetworksRequest_Returns_Valid_UriPathParameters()
        {
            var request = new NetworksRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.HaveCount(0);
        }
    }
}
