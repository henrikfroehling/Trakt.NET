namespace TraktApiSharp.Tests.Objects.Get.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserFollowRequestTests
    {
        [TestMethod]
        public void TestTraktUserFollowRequestDefaultConstructor()
        {
            var followRequest = new TraktUserFollowRequest();

            followRequest.Id.Should().Be(0);
            followRequest.RequestedAt.Should().NotHaveValue();
            followRequest.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserFollowRequestReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserFollowRequest.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var followRequest = JsonConvert.DeserializeObject<TraktUserFollowRequest>(jsonFile);

            followRequest.Should().NotBeNull();

            followRequest.Id.Should().Be(3);
            followRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-22T04:23:48.000Z").ToUniversalTime());
            followRequest.User.Should().NotBeNull();
            followRequest.User.Username.Should().Be("sean");
            followRequest.User.Private.Should().BeFalse();
            followRequest.User.Name.Should().Be("Sean Rudford");
            followRequest.User.VIP.Should().BeTrue();
            followRequest.User.VIP_EP.Should().BeFalse();
        }
    }
}
