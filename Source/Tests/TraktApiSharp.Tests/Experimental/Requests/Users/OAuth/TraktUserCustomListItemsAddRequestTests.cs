namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Post.Users.CustomListItems;
    using TraktApiSharp.Objects.Post.Users.CustomListItems.Responses;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCustomListItemsAddRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListItemsAddRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestIsSealed()
        {
            typeof(TraktUserCustomListItemsAddRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestIsSubclassOfATraktUsersPostByIdRequest()
        {
            typeof(TraktUserCustomListItemsAddRequest).IsSubclassOf(typeof(ATraktUsersPostByIdRequest<TraktUserCustomListItemsPostResponse, TraktUserCustomListItemsPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestHasAuthorizationRequired()
        {
            var request = new TraktUserCustomListItemsAddRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestHasValidUriTemplate()
        {
            var request = new TraktUserCustomListItemsAddRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items{/type}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestHasValidRequestObjectType()
        {
            var request = new TraktUserCustomListItemsAddRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCustomListItemsAddRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestHasTypeProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCustomListItemsAddRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(TraktListItemType));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsAddRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktUserCustomListItemsAddRequest).GetMethods()
                                                                       .Where(m => m.Name == "GetUriPathParameters")
                                                                       .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
