namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCustomListItemsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListItemsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestIsSealed()
        {
            typeof(TraktUserCustomListItemsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktUserCustomListItemsRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktListItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestHasValidRequestObjectType()
        {
            var request = new TraktUserCustomListItemsRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestHasValidUriTemplate()
        {
            var request = new TraktUserCustomListItemsRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists/{id}/items{/type}{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListItemsRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCustomListItemsRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
