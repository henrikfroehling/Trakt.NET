namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;

    [TestClass]
    public class TraktUserFollowersRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestIsNotAbstract()
        {
            typeof(TraktUserFollowersRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestIsSealed()
        {
            typeof(TraktUserFollowersRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFollowersRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserFollowersRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktUserFollower>)).Should().BeTrue();
        }
    }
}
