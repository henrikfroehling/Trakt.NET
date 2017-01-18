namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserSingleFriendTests
    {
        [TestMethod]
        public void TestTraktUserSingleFriendDefaultConstructor()
        {
            var friend = new TraktUserFriend();

            friend.FriendsAt.Should().NotHaveValue();
            friend.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserSingleFriendReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserSingleFriend.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var friend = JsonConvert.DeserializeObject<TraktUserFriend>(jsonFile);

            friend.Should().NotBeNull();
            friend.FriendsAt.Should().Be(DateTime.Parse("2014-10-09T09:10:11.000Z").ToUniversalTime());
            friend.User.Should().NotBeNull();
        }
    }
}
