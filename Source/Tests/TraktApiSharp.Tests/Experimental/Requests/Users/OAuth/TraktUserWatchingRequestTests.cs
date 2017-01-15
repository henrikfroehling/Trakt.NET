namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserWatchingRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchingRequestIsNotAbstract()
        {
            typeof(TraktUserWatchingRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchingRequestIsSealed()
        {
            typeof(TraktUserWatchingRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchingRequestIsSubclassOfATraktUsersSingleItemGetRequest()
        {
            typeof(TraktUserWatchingRequest).IsSubclassOf(typeof(ATraktUsersSingleItemGetRequest<TraktUserWatchingItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchingRequestHasAuthorizationOptional()
        {
            var request = new TraktUserWatchingRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchingRequestHasValidUriTemplate()
        {
            var request = new TraktUserWatchingRequest(null);
            request.UriTemplate.Should().Be("users/{username}/watching{?extended}");
        }
    }
}
