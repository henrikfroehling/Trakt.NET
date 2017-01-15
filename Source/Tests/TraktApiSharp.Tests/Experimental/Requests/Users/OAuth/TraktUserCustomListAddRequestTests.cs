namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
