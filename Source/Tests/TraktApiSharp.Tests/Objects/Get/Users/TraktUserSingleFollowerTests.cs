namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserSingleFollowerTests
    {
        [TestMethod]
        public void TestTraktUserSingleFollowerDefaultConstructor()
        {
            var follower = new TraktUserFollower();

            follower.FollowedAt.Should().NotHaveValue();
            follower.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserSingleFollowerReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserSingleFollower.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var follower = JsonConvert.DeserializeObject<TraktUserFollower>(jsonFile);

            follower.Should().NotBeNull();
            follower.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            follower.User.Should().NotBeNull();
        }
    }
}
