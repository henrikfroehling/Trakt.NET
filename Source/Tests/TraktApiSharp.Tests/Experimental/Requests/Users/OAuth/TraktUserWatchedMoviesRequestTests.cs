namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Watched;

    [TestClass]
    public class TraktUserWatchedMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedMoviesRequestIsNotAbstract()
        {
            typeof(TraktUserWatchedMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedMoviesRequestIsSealed()
        {
            typeof(TraktUserWatchedMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedMoviesRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserWatchedMoviesRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktWatchedMovie>)).Should().BeTrue();
        }
    }
}
