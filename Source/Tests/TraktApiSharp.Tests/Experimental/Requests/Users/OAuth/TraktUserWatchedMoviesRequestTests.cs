namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Watched;
    using TraktApiSharp.Requests;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedMoviesRequestHasAuthorizationOptional()
        {
            var request = new TraktUserWatchedMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedMoviesRequestHasValidUriTemplate()
        {
            var request = new TraktUserWatchedMoviesRequest(null);
            request.UriTemplate.Should().Be("users/{username}/watched/movies{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchedMoviesRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserWatchedMoviesRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
