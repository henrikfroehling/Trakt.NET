namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;

    [TestClass]
    public class TraktUserFriendsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestIsNotAbstract()
        {
            typeof(TraktUserFriendsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestIsSealed()
        {
            typeof(TraktUserFriendsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserFriendsRequestIsSubclassOfATraktUsersListGetRequest()
        {
            typeof(TraktUserFriendsRequest).IsSubclassOf(typeof(ATraktUsersListGetRequest<TraktUserFriend>)).Should().BeTrue();
        }
    }
}
