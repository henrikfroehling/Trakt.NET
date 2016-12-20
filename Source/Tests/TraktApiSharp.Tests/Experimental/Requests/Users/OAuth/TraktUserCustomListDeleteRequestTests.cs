namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
