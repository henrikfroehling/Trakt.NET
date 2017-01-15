namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;

    [TestClass]
    public class TraktUserListLikeRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListLikeRequestIsNotAbstract()
        {
            typeof(TraktUserListLikeRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListLikeRequestIsSealed()
        {
            typeof(TraktUserListLikeRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserListLikeRequestIsSubclassOfATraktNoContentBodylessPostByIdRequest()
        {
            typeof(TraktUserListLikeRequest).IsSubclassOf(typeof(ATraktNoContentBodylessPostByIdRequest)).Should().BeTrue();
        }
    }
}
