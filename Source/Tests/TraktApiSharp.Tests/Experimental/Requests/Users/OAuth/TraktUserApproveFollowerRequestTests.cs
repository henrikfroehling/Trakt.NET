namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Post.Bodyless;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;

    [TestClass]
    public class TraktUserApproveFollowerRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserApproveFollowerRequestIsNotAbstract()
        {
            typeof(TraktUserApproveFollowerRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserApproveFollowerRequestIsSealed()
        {
            typeof(TraktUserApproveFollowerRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserApproveFollowerRequestIsSubclassOfATraktSingleItemBodylessPostByIdRequest()
        {
            typeof(TraktUserApproveFollowerRequest).IsSubclassOf(typeof(ATraktSingleItemBodylessPostByIdRequest<TraktUserFollower>)).Should().BeTrue();
        }
    }
}
