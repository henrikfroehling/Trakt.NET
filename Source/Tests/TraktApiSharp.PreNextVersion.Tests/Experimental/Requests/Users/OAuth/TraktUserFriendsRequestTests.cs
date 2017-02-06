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
    public class TraktUserFriendsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestIsNotAbstract()
        {
            typeof(TraktUserFriendsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestIsSealed()
        {
            typeof(TraktUserFriendsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserFriendsRequest).IsSubclassOf(typeof(ATraktUsersGetRequest<TraktUserFriend>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestHasAuthorizationOptional()
        {
            var request = new TraktUserFriendsRequest(null);
            //request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestHasValidUriTemplate()
        {
            var request = new TraktUserFriendsRequest(null);
            request.UriTemplate.Should().Be("users/{username}/friends{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserFriendsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserFriendsRequest).GetMethods()
                                                            .Where(m => m.Name == "GetUriPathParameters")
                                                            .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestUriParamsWithUsername()
        {
            var username = "username";

            var request = new TraktUserFriendsRequest(null)
            {
                Username = username
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }
    }
}
