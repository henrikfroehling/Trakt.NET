namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserFollowersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestIsNotAbstract()
        {
            typeof(TraktUserFollowersRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestIsSealed()
        {
            typeof(TraktUserFollowersRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserFollowersRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktUserFollower>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestHasAuthorizationOptional()
        {
            var request = new TraktUserFollowersRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestHasValidUriTemplate()
        {
            var request = new TraktUserFollowersRequest(null);
            request.UriTemplate.Should().Be("users/{username}/followers{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserFollowersRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserFollowersRequest).GetMethods()
                                                              .Where(m => m.Name == "GetUriPathParameters")
                                                              .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestUriParamsWithUsername()
        {
            var username = "username";

            var request = new TraktUserFollowersRequest(null)
            {
                Username = username
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }
    }
}
