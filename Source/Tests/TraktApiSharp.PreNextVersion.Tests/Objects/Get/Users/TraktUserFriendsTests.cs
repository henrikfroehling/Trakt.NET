namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserFriendsTests
    {
        [TestMethod]
        public void TestTraktUserFriendsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFriends.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var followers = JsonConvert.DeserializeObject<IEnumerable<TraktUserFriend>>(jsonFile);

            followers.Should().NotBeNull().And.HaveCount(2);

            var followersArray = followers.ToArray();

            followersArray[0].FriendsAt.Should().Be(DateTime.Parse("2014-10-09T09:10:11.000Z").ToUniversalTime());
            followersArray[0].User.Should().NotBeNull();

            followersArray[1].FriendsAt.Should().Be(DateTime.Parse("2014-11-02T09:10:11.000Z").ToUniversalTime());
            followersArray[1].User.Should().NotBeNull();
        }
    }
}
