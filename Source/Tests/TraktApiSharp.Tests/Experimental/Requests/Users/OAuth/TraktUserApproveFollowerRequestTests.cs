namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserApproveFollowerRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserApproveFollowerRequestIsNotAbstract()
        {
            typeof(TraktUserApproveFollowerRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserApproveFollowerRequestIsSealed()
        {
            typeof(TraktUserApproveFollowerRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserApproveFollowerRequestIsSubclassOfATraktSingleItemBodylessPostByIdRequest()
        {
            typeof(TraktUserApproveFollowerRequest).IsSubclassOf(typeof(ATraktSingleItemBodylessPostByIdRequest<TraktUserFollower>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserApproveFollowerRequestHasAuthorizationRequired()
        {
            var request = new TraktUserApproveFollowerRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserApproveFollowerRequestHasValidUriTemplate()
        {
            var request = new TraktUserApproveFollowerRequest(null);
            request.UriTemplate.Should().Be("users/requests/{id}");
        }
    }
}
