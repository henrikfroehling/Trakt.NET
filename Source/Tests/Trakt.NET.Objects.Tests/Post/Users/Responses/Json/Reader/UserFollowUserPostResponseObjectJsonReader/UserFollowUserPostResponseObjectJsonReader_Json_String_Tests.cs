namespace TraktNet.Objects.Tests.Post.Users.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Users.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonReader")]
    public partial class UserFollowUserPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserFollowUserPostResponseObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userFollowUserPostResponse.Should().NotBeNull();

            userFollowUserPostResponse.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());

            userFollowUserPostResponse.User.Should().NotBeNull();
            userFollowUserPostResponse.User.Username.Should().Be("sean");
            userFollowUserPostResponse.User.IsPrivate.Should().BeFalse();
            userFollowUserPostResponse.User.Name.Should().Be("Sean Rudford");
            userFollowUserPostResponse.User.IsVIP.Should().BeTrue();
            userFollowUserPostResponse.User.IsVIP_EP.Should().BeTrue();
            userFollowUserPostResponse.User.Ids.Should().NotBeNull();
            userFollowUserPostResponse.User.Ids.Slug.Should().Be("sean");
            userFollowUserPostResponse.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowUserPostResponse.User.Location.Should().Be("SF");
            userFollowUserPostResponse.User.About.Should().Be("I have all your cassette tapes.");
            userFollowUserPostResponse.User.Gender.Should().Be("male");
            userFollowUserPostResponse.User.Age.Should().Be(35);
            userFollowUserPostResponse.User.Images.Should().NotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Should().NotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowUserPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userFollowUserPostResponse.Should().NotBeNull();

            userFollowUserPostResponse.ApprovedAt.Should().BeNull();

            userFollowUserPostResponse.User.Should().NotBeNull();
            userFollowUserPostResponse.User.Username.Should().Be("sean");
            userFollowUserPostResponse.User.IsPrivate.Should().BeFalse();
            userFollowUserPostResponse.User.Name.Should().Be("Sean Rudford");
            userFollowUserPostResponse.User.IsVIP.Should().BeTrue();
            userFollowUserPostResponse.User.IsVIP_EP.Should().BeTrue();
            userFollowUserPostResponse.User.Ids.Should().NotBeNull();
            userFollowUserPostResponse.User.Ids.Slug.Should().Be("sean");
            userFollowUserPostResponse.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowUserPostResponse.User.Location.Should().Be("SF");
            userFollowUserPostResponse.User.About.Should().Be("I have all your cassette tapes.");
            userFollowUserPostResponse.User.Gender.Should().Be("male");
            userFollowUserPostResponse.User.Age.Should().Be(35);
            userFollowUserPostResponse.User.Images.Should().NotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Should().NotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowUserPostResponseObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userFollowUserPostResponse.Should().NotBeNull();

            userFollowUserPostResponse.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());

            userFollowUserPostResponse.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowUserPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userFollowUserPostResponse.Should().NotBeNull();

            userFollowUserPostResponse.ApprovedAt.Should().BeNull();

            userFollowUserPostResponse.User.Should().NotBeNull();
            userFollowUserPostResponse.User.Username.Should().Be("sean");
            userFollowUserPostResponse.User.IsPrivate.Should().BeFalse();
            userFollowUserPostResponse.User.Name.Should().Be("Sean Rudford");
            userFollowUserPostResponse.User.IsVIP.Should().BeTrue();
            userFollowUserPostResponse.User.IsVIP_EP.Should().BeTrue();
            userFollowUserPostResponse.User.Ids.Should().NotBeNull();
            userFollowUserPostResponse.User.Ids.Slug.Should().Be("sean");
            userFollowUserPostResponse.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowUserPostResponse.User.Location.Should().Be("SF");
            userFollowUserPostResponse.User.About.Should().Be("I have all your cassette tapes.");
            userFollowUserPostResponse.User.Gender.Should().Be("male");
            userFollowUserPostResponse.User.Age.Should().Be(35);
            userFollowUserPostResponse.User.Images.Should().NotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Should().NotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowUserPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userFollowUserPostResponse.Should().NotBeNull();

            userFollowUserPostResponse.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());

            userFollowUserPostResponse.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowUserPostResponseObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userFollowUserPostResponse.Should().NotBeNull();

            userFollowUserPostResponse.ApprovedAt.Should().BeNull();
            userFollowUserPostResponse.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowUserPostResponseObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(default(string));
            userFollowUserPostResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowUserPostResponseObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(string.Empty);
            userFollowUserPostResponse.Should().BeNull();
        }
    }
}
