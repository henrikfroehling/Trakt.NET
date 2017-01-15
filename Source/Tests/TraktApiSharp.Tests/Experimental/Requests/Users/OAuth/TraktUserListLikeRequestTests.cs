namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserListLikeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListLikeRequestIsNotAbstract()
        {
            typeof(TraktUserListLikeRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListLikeRequestIsSealed()
        {
            typeof(TraktUserListLikeRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListLikeRequestIsSubclassOfATraktNoContentBodylessPostByIdRequest()
        {
            typeof(TraktUserListLikeRequest).IsSubclassOf(typeof(ATraktNoContentBodylessPostByIdRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListLikeRequestHasAuthorizationRequired()
        {
            var request = new TraktUserListLikeRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListLikeRequestHasValidUriTemplate()
        {
            var request = new TraktUserListLikeRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/like");
        }
    }
}
