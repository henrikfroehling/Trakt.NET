namespace TraktApiSharp.Tests.Requests.Networks
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Networks;
    using Xunit;

    [Category("Requests.Networks")]
    public class NetworksRequest_Tests
    {
        [Fact]
        public void Test_NetworksRequest_IsNotAbstract()
        {
            typeof(NetworksRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_NetworksRequest_IsSealed()
        {
            typeof(NetworksRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_NetworksRequest_Inherits_AGetRequest_1()
        {
            typeof(NetworksRequest).IsSubclassOf(typeof(AGetRequest<ITraktNetwork>)).Should().BeTrue();
        }

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
