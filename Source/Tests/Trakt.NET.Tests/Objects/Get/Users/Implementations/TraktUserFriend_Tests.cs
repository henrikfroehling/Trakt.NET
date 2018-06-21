namespace TraktNet.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserFriend_Tests
    {
        [Fact]
        public void Test_TraktUserFriend_Default_Constructor()
        {
            var userFriend = new TraktUserFriend();

            userFriend.FriendsAt.Should().BeNull();
            userFriend.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserFriend_From_Json()
        {
            var jsonReader = new UserFriendObjectJsonReader();
            var userFriend = await jsonReader.ReadObjectAsync(JSON) as TraktUserFriend;

            userFriend.Should().NotBeNull();
            userFriend.FriendsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFriend.User.Should().NotBeNull();
            userFriend.User.Username.Should().Be("sean");
            userFriend.User.IsPrivate.Should().BeFalse();
            userFriend.User.Name.Should().Be("Sean Rudford");
            userFriend.User.IsVIP.Should().BeTrue();
            userFriend.User.IsVIP_EP.Should().BeTrue();
            userFriend.User.Ids.Should().NotBeNull();
            userFriend.User.Ids.Slug.Should().Be("sean");
            userFriend.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFriend.User.Location.Should().Be("SF");
            userFriend.User.About.Should().Be("I have all your cassette tapes.");
            userFriend.User.Gender.Should().Be("male");
            userFriend.User.Age.Should().Be(35);
            userFriend.User.Images.Should().NotBeNull();
            userFriend.User.Images.Avatar.Should().NotBeNull();
            userFriend.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/userFriends/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        private const string JSON =
            @"{
                ""friends_at"": ""2014-09-01T09:10:11.000Z"",
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
                      ""full"": ""https://walter-dev.trakt.tv/images/userFriends/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  }
                }
              }";
    }
}
