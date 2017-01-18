namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserFollowRequestsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowRequestsRequestIsNotAbstract()
        {
            typeof(TraktUserFollowRequestsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowRequestsRequestIsSealed()
        {
            typeof(TraktUserFollowRequestsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowRequestsRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserFollowRequestsRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktUserFollowRequest>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowRequestsRequestHasAuthorizationRequired()
        {
            var request = new TraktUserFollowRequestsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowRequestsRequestHasValidUriTemplate()
        {
            var request = new TraktUserFollowRequestsRequest(null);
            request.UriTemplate.Should().Be("users/requests{?extended}");
        }
    }
}
