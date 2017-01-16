namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Put;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Objects.Post.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCustomListUpdateRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestIsNotAbstract()
        {
            typeof(TraktUserCustomListUpdateRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestIsSealed()
        {
            typeof(TraktUserCustomListUpdateRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestIsSubclassOfATraktSingleItemPutByIdRequest()
        {
            typeof(TraktUserCustomListUpdateRequest).IsSubclassOf(typeof(ATraktSingleItemPutByIdRequest<TraktList, TraktUserCustomListPost>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestHasAuthorizationRequired()
        {
            var request = new TraktUserCustomListUpdateRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestHasValidUriTemplate()
        {
            var request = new TraktUserCustomListUpdateRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestHasValidRequestObjectType()
        {
            var request = new TraktUserCustomListUpdateRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.Lists);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomListUpdateRequestHasUsernameProperty()
        {
            var sortingPropertyInfo = typeof(TraktUserCustomListUpdateRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Username")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
