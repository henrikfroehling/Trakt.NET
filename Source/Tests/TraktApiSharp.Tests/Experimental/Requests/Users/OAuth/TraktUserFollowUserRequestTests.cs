namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserFollowUserRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestIsNotAbstract()
        {
            typeof(TraktUserFollowUserRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestIsSealed()
        {
            typeof(TraktUserFollowUserRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestIsSubclassOfATraktSingleItemBodylessPostRequest()
        {
            typeof(TraktUserFollowUserRequest).IsSubclassOf(typeof(ATraktSingleItemBodylessPostRequest<TraktUserFollowUserPostResponse>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestHasAuthorizationRequired()
        {
            var request = new TraktUserFollowUserRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }
    }
}
