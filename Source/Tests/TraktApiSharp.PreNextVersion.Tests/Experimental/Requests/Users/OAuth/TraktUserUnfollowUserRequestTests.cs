namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserUnfollowUserRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestIsNotAbstract()
        {
            typeof(TraktUserUnfollowUserRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestIsSealed()
        {
            typeof(TraktUserUnfollowUserRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestIsSubclassOfATraktNoContentDeleteRequest()
        {
            typeof(TraktUserUnfollowUserRequest).IsSubclassOf(typeof(ATraktNoContentDeleteRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestHasAuthorizationRequired()
        {
            var request = new TraktUserUnfollowUserRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestHasValidUriTemplate()
        {
            var request = new TraktUserUnfollowUserRequest(null);
            request.UriTemplate.Should().Be("users/{username}/follow");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserUnfollowUserRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserUnfollowUserRequest).GetMethods()
                                                                 .Where(m => m.Name == "GetUriPathParameters")
                                                                 .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserUnfollowUserRequestUriParamsWithUsername()
        {
            var username = "username";

            var request = new TraktUserUnfollowUserRequest(null)
            {
                Username = username
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }
    }
}
