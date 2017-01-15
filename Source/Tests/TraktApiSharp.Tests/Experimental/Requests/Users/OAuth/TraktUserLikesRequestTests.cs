namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserLikesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserLikesRequestIsNotAbstract()
        {
            typeof(TraktUserLikesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserLikesRequestIsSealed()
        {
            typeof(TraktUserLikesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserLikesRequestIsSubclassOfATraktPaginationGetRequest()
        {
            typeof(TraktUserLikesRequest).IsSubclassOf(typeof(ATraktPaginationGetRequest<TraktUserLikeItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserLikesRequestHasAuthorizationRequired()
        {
            var request = new TraktUserLikesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserLikesRequestHasValidUriTemplate()
        {
            var request = new TraktUserLikesRequest(null);
            request.UriTemplate.Should().Be("users/likes{/type}{?page,limit}");
        }
    }
}
