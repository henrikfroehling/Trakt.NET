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
    public class TraktUserCustomSingleListRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestIsNotAbstract()
        {
            typeof(TraktUserCustomSingleListRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestIsSealed()
        {
            typeof(TraktUserCustomSingleListRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            //typeof(TraktUserCustomSingleListRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktList>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestHasAuthorizationOptional()
        {
            var request = new TraktUserCustomSingleListRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestHasValidUriTemplate()
        {
            var request = new TraktUserCustomSingleListRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestHasValidRequestObjectType()
        {
            var request = new TraktUserCustomSingleListRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCustomSingleListRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserCustomSingleListRequest).GetMethods()
                                                                     .Where(m => m.Name == "GetUriPathParameters")
                                                                     .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestUriParamsWithUsername()
        {
            var username = "username";

            var request = new TraktUserCustomSingleListRequest(null)
            {
                Username = username
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("username", username);
        }
    }
}
