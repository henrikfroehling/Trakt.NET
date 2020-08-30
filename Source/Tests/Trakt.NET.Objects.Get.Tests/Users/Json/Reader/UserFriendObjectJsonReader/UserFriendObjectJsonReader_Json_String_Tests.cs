namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserFriendObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserFriendObjectJsonReader();

            var userFriend = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserFriendObjectJsonReader();

            var userFriend = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserFriendObjectJsonReader();

            var userFriend = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userFriend.Should().NotBeNull();
            userFriend.FriendsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFriend.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserFriendObjectJsonReader();

            var userFriend = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserFriendObjectJsonReader();

            var userFriend = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userFriend.Should().NotBeNull();
            userFriend.FriendsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFriend.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserFriendObjectJsonReader();

            var userFriend = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userFriend.Should().NotBeNull();
            userFriend.FriendsAt.Should().BeNull();
            userFriend.User.Should().BeNull();
        }

        [Fact]
        public void Test_UserFriendObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserFriendObjectJsonReader();
            Func<Task<ITraktUserFriend>> userFriend = () => jsonReader.ReadObjectAsync(default(string));
            userFriend.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_UserFriendObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserFriendObjectJsonReader();

            var userFriend = await jsonReader.ReadObjectAsync(string.Empty);
            userFriend.Should().BeNull();
        }
    }
}
