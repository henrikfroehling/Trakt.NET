namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMovieWatchingUsersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieWatchingUsersRequestIsNotAbstract()
        {
            typeof(TraktMovieWatchingUsersRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieWatchingUsersRequestIsSealed()
        {
            typeof(TraktMovieWatchingUsersRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieWatchingUsersRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktMovieWatchingUsersRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktUser>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieWatchingUsersRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieWatchingUsersRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieWatchingUsersRequestHasValidUriTemplate()
        {
            var request = new TraktMovieWatchingUsersRequest(null);
            request.UriTemplate.Should().Be("movies/{id}/watching{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieWatchingUsersRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktMovieWatchingUsersRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }
    }
}
