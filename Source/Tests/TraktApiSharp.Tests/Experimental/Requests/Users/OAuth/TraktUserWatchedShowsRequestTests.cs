namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserWatchedShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedShowsRequestIsNotAbstract()
        {
            typeof(TraktUserWatchedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedShowsRequestIsSealed()
        {
            typeof(TraktUserWatchedShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedShowsRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserWatchedShowsRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktWatchedShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedShowsRequestHasAuthorizationOptional()
        {
            var request = new TraktUserWatchedShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedShowsRequestHasValidUriTemplate()
        {
            var request = new TraktUserWatchedShowsRequest(null);
            request.UriTemplate.Should().Be("users/{username}/watched/shows{?extended}");
        }
    }
}
