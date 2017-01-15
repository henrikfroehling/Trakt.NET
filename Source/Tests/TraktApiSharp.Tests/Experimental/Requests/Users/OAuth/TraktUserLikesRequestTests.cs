namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;

    [TestClass]
    public class TraktUserLikesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserLikesRequestIsNotAbstract()
        {
            typeof(TraktUserLikesRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserLikesRequestIsSealed()
        {
            typeof(TraktUserLikesRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserLikesRequestIsSubclassOfATraktPaginationGetRequest()
        {
            typeof(TraktUserLikesRequest).IsSubclassOf(typeof(ATraktPaginationGetRequest<TraktUserLikeItem>)).Should().BeTrue();
        }
    }
}
