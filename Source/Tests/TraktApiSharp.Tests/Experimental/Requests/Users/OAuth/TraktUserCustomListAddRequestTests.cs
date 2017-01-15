namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Post;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Post.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCustomListAddRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListAddRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListAddRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListAddRequestIsSealed()
        {
            typeof(TraktUserCustomListAddRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListAddRequestIsSubclassOfATraktSingleItemPostRequest()
        {
            typeof(TraktUserCustomListAddRequest).IsSubclassOf(typeof(ATraktSingleItemPostRequest<TraktList, TraktUserCustomListPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListAddRequestHasAuthorizationRequired()
        {
            var request = new TraktUserCustomListAddRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListAddRequestHasValidUriTemplate()
        {
            var request = new TraktUserCustomListAddRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListAddRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCustomListAddRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListAddRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserCustomListAddRequest).GetMethods()
                                                                  .Where(m => m.Name == "GetUriPathParameters")
                                                                  .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
