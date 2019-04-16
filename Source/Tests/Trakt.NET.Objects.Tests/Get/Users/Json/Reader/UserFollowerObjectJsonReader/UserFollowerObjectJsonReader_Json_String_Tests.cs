namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserFollowerObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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
            userFollower.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userFollower.Should().NotBeNull();
            userFollower.FollowedAt.Should().BeNull();

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
            userFollower.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userFollower.Should().NotBeNull();
            userFollower.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFollower.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userFollower.Should().NotBeNull();
            userFollower.FollowedAt.Should().BeNull();

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
            userFollower.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userFollower.Should().NotBeNull();
            userFollower.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFollower.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userFollower.Should().NotBeNull();
            userFollower.FollowedAt.Should().BeNull();
            userFollower.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await jsonReader.ReadObjectAsync(default(string));
            userFollower.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await jsonReader.ReadObjectAsync(string.Empty);
            userFollower.Should().BeNull();
        }
    }
}
