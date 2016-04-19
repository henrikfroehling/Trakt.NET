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
    public class TraktUserFollowersTests
    {
        [TestMethod]
        public void TestTraktUserFollowersReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Users\UserFollowers.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var followers = JsonConvert.DeserializeObject<IEnumerable<TraktUserFollower>>(jsonFile);

            followers.Should().NotBeNull().And.HaveCount(2);

            var followersArray = followers.ToArray();

            followersArray[0].FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            followersArray[0].User.Should().NotBeNull();

            followersArray[1].FollowedAt.Should().Be(DateTime.Parse("2014-10-01T09:10:11.000Z").ToUniversalTime());
            followersArray[1].User.Should().NotBeNull();
        }
    }
}
