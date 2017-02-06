namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserProfileRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestIsNotAbstract()
        {
            typeof(TraktUserProfileRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestIsSealed()
        {
            typeof(TraktUserProfileRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestIsSubclassOfATraktUsersSingleItemGetRequest()
        {
            //typeof(TraktUserProfileRequest).IsSubclassOf(typeof(ATraktUsersSingleItemGetRequest<TraktUser>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestHasAuthorizationOptional()
        {
            var request = new TraktUserProfileRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestHasValidUriTemplate()
        {
            var request = new TraktUserProfileRequest(null);
            request.UriTemplate.Should().Be("users/{username}{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktUserProfileRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserProfileRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserProfileRequest).GetMethods()
                                                            .Where(m => m.Name == "GetUriPathParameters")
                                                            .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserProfileRequestUriParamsWithUsername()
        {
            var username = "username";

            var request = new TraktUserProfileRequest(null)
            {
                Username = username
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }
    }
}
