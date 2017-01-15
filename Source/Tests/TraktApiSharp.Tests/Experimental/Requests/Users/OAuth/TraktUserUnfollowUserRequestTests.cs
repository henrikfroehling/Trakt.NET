namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserUnfollowUserRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestIsNotAbstract()
        {
            typeof(TraktUserUnfollowUserRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestIsSealed()
        {
            typeof(TraktUserUnfollowUserRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestIsSubclassOfATraktNoContentDeleteRequest()
        {
            typeof(TraktUserUnfollowUserRequest).IsSubclassOf(typeof(ATraktNoContentDeleteRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestHasAuthorizationRequired()
        {
            var request = new TraktUserUnfollowUserRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestHasValidUriTemplate()
        {
            var request = new TraktUserUnfollowUserRequest(null);
            request.UriTemplate.Should().Be("users/{username}/follow");
        }
    }
}
