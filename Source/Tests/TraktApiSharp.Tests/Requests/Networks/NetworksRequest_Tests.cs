namespace TraktApiSharp.Tests.Requests.Networks
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Networks;
    using Xunit;

    [Category("Requests.Networks")]
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
