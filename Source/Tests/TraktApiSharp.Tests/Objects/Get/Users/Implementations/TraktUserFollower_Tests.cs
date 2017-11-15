namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using TraktApiSharp.Objects.Get.Users.Json;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserFollower_Tests
    {
        [Fact]
        public void Test_TraktUserFollower_Default_Constructor()
        {
            var userFollower = new TraktUserFollower();

            userFollower.FollowedAt.Should().BeNull();
            userFollower.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserFollower_From_Json()
        {
            var jsonReader = new UserFollowerObjectJsonReader();
            var userFollower = await jsonReader.ReadObjectAsync(JSON) as TraktUserFollower;

            userFollower.Should().NotBeNull();
            userFollower.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFollower.User.Should().NotBeNull();
            userFollower.User.Username.Should().Be("sean");
            userFollower.User.IsPrivate.Should().BeFalse();
            userFollower.User.Name.Should().Be("Sean Rudford");
            userFollower.User.IsVIP.Should().BeTrue();
            userFollower.User.IsVIP_EP.Should().BeTrue();
            userFollower.User.Ids.Should().NotBeNull();
            userFollower.User.Ids.Slug.Should().Be("sean");
            userFollower.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollower.User.Location.Should().Be("SF");
            userFollower.User.About.Should().Be("I have all your cassette tapes.");
            userFollower.User.Gender.Should().Be("male");
            userFollower.User.Age.Should().Be(35);
            userFollower.User.Images.Should().NotBeNull();
            userFollower.User.Images.Avatar.Should().NotBeNull();
            userFollower.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/userFollowers/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        private const string JSON =
            @"{
                ""followed_at"": ""2014-09-01T09:10:11.000Z"",
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/userFollowers/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  }
                }
              }";
    }
}
