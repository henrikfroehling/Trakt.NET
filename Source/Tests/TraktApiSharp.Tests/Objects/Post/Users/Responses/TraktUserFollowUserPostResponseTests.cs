namespace TraktApiSharp.Tests.Objects.Post.Users.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using Utils;

    [TestClass]
    public class TraktUserFollowUserPostResponseTests
    {
        [TestMethod]
        public void TestTraktUserFollowUserPostResponseDefaultConstructor()
        {
            var userFollowUserResponse = new TraktUserFollowUserPostResponse();

            userFollowUserResponse.ApprovedAt.Should().NotHaveValue();
            userFollowUserResponse.User.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserFollowUserPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Users\Responses\FollowUserPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userFollowUserResponse = JsonConvert.DeserializeObject<TraktUserFollowUserPostResponse>(jsonFile);

            userFollowUserResponse.Should().NotBeNull();
            userFollowUserResponse.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());
            userFollowUserResponse.User.Should().NotBeNull();
            userFollowUserResponse.User.Username.Should().Be("sean");
            userFollowUserResponse.User.Private.Should().BeFalse();
            userFollowUserResponse.User.Name.Should().Be("Sean Rudford");
            userFollowUserResponse.User.VIP.Should().BeTrue();
            userFollowUserResponse.User.VIP_EP.Should().BeFalse();
        }
    }
}
