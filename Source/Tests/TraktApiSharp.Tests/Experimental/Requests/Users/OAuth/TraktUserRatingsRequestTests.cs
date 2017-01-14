namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestIsNotAbstract()
        {
            typeof(TraktUserRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestIsSealed()
        {
            typeof(TraktUserRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserRatingsRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktRatingsItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserRatingsRequestHasAuthorizationOptional()
        {
            var request = new TraktUserRatingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }
    }
}
