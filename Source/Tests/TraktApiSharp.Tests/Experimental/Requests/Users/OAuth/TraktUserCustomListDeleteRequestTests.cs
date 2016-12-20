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
    public class TraktUserCustomListDeleteRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListDeleteRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestIsSealed()
        {
            typeof(TraktUserCustomListDeleteRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestIsSubclassOfATraktUsersDeleteByIdRequest()
        {
            typeof(TraktUserCustomListDeleteRequest).IsSubclassOf(typeof(ATraktUsersDeleteByIdRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestHasValidRequestObjectType()
        {
            var request = new TraktUserCustomListDeleteRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestHasValidUriTemplate()
        {
            var request = new TraktUserCustomListDeleteRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCustomListDeleteRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListDeleteRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserCustomListDeleteRequest).GetMethods()
                                                                     .Where(m => m.Name == "GetUriPathParameters")
                                                                     .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
