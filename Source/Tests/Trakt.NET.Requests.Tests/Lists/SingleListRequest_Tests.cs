namespace TraktNet.Requests.Tests.Lists
{
    using FluentAssertions;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Base;
    using TraktNet.Requests.Lists;
    using Xunit;

    [TestCategory("Requests.Lists")]
    public class SingleListRequest_Tests
    {
        [Fact]
        public void Test_SingleListRequest_Has_AuthorizationRequirement_Optional()
        {
            var request = new SingleListRequest();
            request.AuthorizationRequirement.Should().Be(AuthorizationRequirement.NotRequired);
        }

        [Fact]
        public void Test_SingleListRequest_Returns_Valid_RequestObjectType()
        {
            var request = new SingleListRequest();
            request.RequestObjectType.Should().Be(RequestObjectType.Lists);
        }

        [Fact]
        public void Test_SingleListRequest_Has_Valid_UriTemplate()
        {
            var request = new SingleListRequest();
            request.UriTemplate.Should().Be("lists/{id}");
        }
    }
}
