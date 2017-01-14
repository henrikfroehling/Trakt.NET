namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Collection;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCollectionMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestIsNotAbstract()
        {
            typeof(TraktUserCollectionMoviesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestIsSealed()
        {
            typeof(TraktUserCollectionMoviesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserCollectionMoviesRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktCollectionMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestHasAuthorizationOptional()
        {
            var request = new TraktUserCollectionMoviesRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestHasValidUriTemplate()
        {
            var request = new TraktUserCollectionMoviesRequest(null);
            request.UriTemplate.Should().Be("users/{username}/collection/movies{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCollectionMoviesRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCollectionMoviesRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
