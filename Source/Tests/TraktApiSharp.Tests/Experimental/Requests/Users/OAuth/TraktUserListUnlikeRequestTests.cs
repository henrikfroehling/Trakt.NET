namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserListUnlikeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListUnlikeRequestIsNotAbstract()
        {
            typeof(TraktUserListUnlikeRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListUnlikeRequestIsSealed()
        {
            typeof(TraktUserListUnlikeRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListUnlikeRequestIsSubclassOfATraktUsersDeleteByIdRequest()
        {
            typeof(TraktUserListUnlikeRequest).IsSubclassOf(typeof(ATraktUsersDeleteByIdRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListUnlikeRequestHasValidRequestObjectType()
        {
            var request = new TraktUserListUnlikeRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListUnlikeRequestHasValidUriTemplate()
        {
            var request = new TraktUserListUnlikeRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/like");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListUnlikeRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserListUnlikeRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListUnlikeRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserListUnlikeRequest).GetMethods()
                                                               .Where(m => m.Name == "GetUriPathParameters")
                                                               .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
