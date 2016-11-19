namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSeasonWatchingUsersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestIsNotAbstract()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestIsSealed()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktSeasonWatchingUsersRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktUser>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestHasAuthorizationNotRequired()
        {
            var request = new TraktSeasonWatchingUsersRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestHasValidUriTemplate()
        {
            var request = new TraktSeasonWatchingUsersRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons/{season}/watching{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktSeasonWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonWatchingUsersRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktSeasonWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
