namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Watchlist;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserWatchlistRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchlistRequestIsNotAbstract()
        {
            typeof(TraktUserWatchlistRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchlistRequestIsSealed()
        {
            typeof(TraktUserWatchlistRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchlistRequestIsSubclassOfATraktUsersPaginationGetRequest()
        {
            typeof(TraktUserWatchlistRequest).IsSubclassOf(typeof(ATraktUsersPaginationGetRequest<TraktWatchlistItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchlistRequestHasAuthorizationOptional()
        {
            var request = new TraktUserWatchlistRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchlistRequestHasValidUriTemplate()
        {
            var request = new TraktUserWatchlistRequest(null);
            request.UriTemplate.Should().Be("users/{username}/watchlist{/type}{?extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchlistRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserWatchlistRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchlistRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserWatchlistRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktSyncItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserWatchlistRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserWatchlistRequest).GetMethods()
                                                              .Where(m => m.Name == "GetUriPathParameters")
                                                              .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
