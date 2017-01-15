namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserFollowUserRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestIsNotAbstract()
        {
            typeof(TraktUserFollowUserRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestIsSealed()
        {
            typeof(TraktUserFollowUserRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestIsSubclassOfATraktSingleItemBodylessPostRequest()
        {
            typeof(TraktUserFollowUserRequest).IsSubclassOf(typeof(ATraktSingleItemBodylessPostRequest<TraktUserFollowUserPostResponse>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestHasAuthorizationRequired()
        {
            var request = new TraktUserFollowUserRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestHasValidUriTemplate()
        {
            var request = new TraktUserFollowUserRequest(null);
            request.UriTemplate.Should().Be("users/{username}/follow");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserFollowUserRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowUserRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserFollowUserRequest).GetMethods()
                                                               .Where(m => m.Name == "GetUriPathParameters")
                                                               .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
