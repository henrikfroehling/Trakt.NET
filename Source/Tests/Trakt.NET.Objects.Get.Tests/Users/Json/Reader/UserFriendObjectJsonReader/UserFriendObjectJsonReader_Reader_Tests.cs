namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserFriendObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserFriendObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFriend = await traktJsonReader.ReadObjectAsync(jsonReader);

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
                userFriend.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            }
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserFriendObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFriend = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFriend.Should().NotBeNull();
                userFriend.FriendsAt.Should().BeNull();

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
                userFriend.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            }
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserFriendObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFriend = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFriend.Should().NotBeNull();
                userFriend.FriendsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                userFriend.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserFriendObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFriend = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFriend.Should().NotBeNull();
                userFriend.FriendsAt.Should().BeNull();

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
                userFriend.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            }
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserFriendObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFriend = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFriend.Should().NotBeNull();
                userFriend.FriendsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                userFriend.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserFriendObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFriend = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFriend.Should().NotBeNull();
                userFriend.FriendsAt.Should().BeNull();
                userFriend.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserFriendObjectJsonReader();

            var userFriend = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userFriend.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserFriendObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFriend = await traktJsonReader.ReadObjectAsync(jsonReader);
                userFriend.Should().BeNull();
            }
        }
    }
}
