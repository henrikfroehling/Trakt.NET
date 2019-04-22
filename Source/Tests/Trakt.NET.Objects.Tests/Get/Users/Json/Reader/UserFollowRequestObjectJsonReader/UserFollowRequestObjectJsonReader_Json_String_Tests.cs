namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserFollowRequestObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(12345U);
            userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFollowRequest.User.Should().NotBeNull();
            userFollowRequest.User.Username.Should().Be("sean");
            userFollowRequest.User.IsPrivate.Should().BeFalse();
            userFollowRequest.User.Name.Should().Be("Sean Rudford");
            userFollowRequest.User.IsVIP.Should().BeTrue();
            userFollowRequest.User.IsVIP_EP.Should().BeTrue();
            userFollowRequest.User.Ids.Should().NotBeNull();
            userFollowRequest.User.Ids.Slug.Should().Be("sean");
            userFollowRequest.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowRequest.User.Location.Should().Be("SF");
            userFollowRequest.User.About.Should().Be("I have all your cassette tapes.");
            userFollowRequest.User.Gender.Should().Be("male");
            userFollowRequest.User.Age.Should().Be(35);
            userFollowRequest.User.Images.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(0U);
            userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFollowRequest.User.Should().NotBeNull();
            userFollowRequest.User.Username.Should().Be("sean");
            userFollowRequest.User.IsPrivate.Should().BeFalse();
            userFollowRequest.User.Name.Should().Be("Sean Rudford");
            userFollowRequest.User.IsVIP.Should().BeTrue();
            userFollowRequest.User.IsVIP_EP.Should().BeTrue();
            userFollowRequest.User.Ids.Should().NotBeNull();
            userFollowRequest.User.Ids.Slug.Should().Be("sean");
            userFollowRequest.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowRequest.User.Location.Should().Be("SF");
            userFollowRequest.User.About.Should().Be("I have all your cassette tapes.");
            userFollowRequest.User.Gender.Should().Be("male");
            userFollowRequest.User.Age.Should().Be(35);
            userFollowRequest.User.Images.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(12345U);
            userFollowRequest.RequestedAt.Should().BeNull();

            userFollowRequest.User.Should().NotBeNull();
            userFollowRequest.User.Username.Should().Be("sean");
            userFollowRequest.User.IsPrivate.Should().BeFalse();
            userFollowRequest.User.Name.Should().Be("Sean Rudford");
            userFollowRequest.User.IsVIP.Should().BeTrue();
            userFollowRequest.User.IsVIP_EP.Should().BeTrue();
            userFollowRequest.User.Ids.Should().NotBeNull();
            userFollowRequest.User.Ids.Slug.Should().Be("sean");
            userFollowRequest.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowRequest.User.Location.Should().Be("SF");
            userFollowRequest.User.About.Should().Be("I have all your cassette tapes.");
            userFollowRequest.User.Gender.Should().Be("male");
            userFollowRequest.User.Age.Should().Be(35);
            userFollowRequest.User.Images.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(12345U);
            userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            userFollowRequest.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(12345U);
            userFollowRequest.RequestedAt.Should().BeNull();
            userFollowRequest.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(0U);
            userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            userFollowRequest.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(0U);
            userFollowRequest.RequestedAt.Should().BeNull();

            userFollowRequest.User.Should().NotBeNull();
            userFollowRequest.User.Username.Should().Be("sean");
            userFollowRequest.User.IsPrivate.Should().BeFalse();
            userFollowRequest.User.Name.Should().Be("Sean Rudford");
            userFollowRequest.User.IsVIP.Should().BeTrue();
            userFollowRequest.User.IsVIP_EP.Should().BeTrue();
            userFollowRequest.User.Ids.Should().NotBeNull();
            userFollowRequest.User.Ids.Slug.Should().Be("sean");
            userFollowRequest.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowRequest.User.Location.Should().Be("SF");
            userFollowRequest.User.About.Should().Be("I have all your cassette tapes.");
            userFollowRequest.User.Gender.Should().Be("male");
            userFollowRequest.User.Age.Should().Be(35);
            userFollowRequest.User.Images.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(0U);
            userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFollowRequest.User.Should().NotBeNull();
            userFollowRequest.User.Username.Should().Be("sean");
            userFollowRequest.User.IsPrivate.Should().BeFalse();
            userFollowRequest.User.Name.Should().Be("Sean Rudford");
            userFollowRequest.User.IsVIP.Should().BeTrue();
            userFollowRequest.User.IsVIP_EP.Should().BeTrue();
            userFollowRequest.User.Ids.Should().NotBeNull();
            userFollowRequest.User.Ids.Slug.Should().Be("sean");
            userFollowRequest.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowRequest.User.Location.Should().Be("SF");
            userFollowRequest.User.About.Should().Be("I have all your cassette tapes.");
            userFollowRequest.User.Gender.Should().Be("male");
            userFollowRequest.User.Age.Should().Be(35);
            userFollowRequest.User.Images.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(12345U);
            userFollowRequest.RequestedAt.Should().BeNull();

            userFollowRequest.User.Should().NotBeNull();
            userFollowRequest.User.Username.Should().Be("sean");
            userFollowRequest.User.IsPrivate.Should().BeFalse();
            userFollowRequest.User.Name.Should().Be("Sean Rudford");
            userFollowRequest.User.IsVIP.Should().BeTrue();
            userFollowRequest.User.IsVIP_EP.Should().BeTrue();
            userFollowRequest.User.Ids.Should().NotBeNull();
            userFollowRequest.User.Ids.Slug.Should().Be("sean");
            userFollowRequest.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowRequest.User.Location.Should().Be("SF");
            userFollowRequest.User.About.Should().Be("I have all your cassette tapes.");
            userFollowRequest.User.Gender.Should().Be("male");
            userFollowRequest.User.Age.Should().Be(35);
            userFollowRequest.User.Images.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(12345U);
            userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFollowRequest.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(0U);
            userFollowRequest.RequestedAt.Should().BeNull();
            userFollowRequest.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(default(string));
            userFollowRequest.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(string.Empty);
            userFollowRequest.Should().BeNull();
        }
    }
}
