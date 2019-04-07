namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserFollowRequestObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(12345U);
                userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(12345U);
                userFollowRequest.RequestedAt.Should().BeNull();
                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(0U);
                userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(12345U);
                userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(0U);
                userFollowRequest.RequestedAt.Should().BeNull();
                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            var userFollowRequest = await jsonReader.ReadObjectAsync(default(Stream));
            userFollowRequest.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowRequestObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserFollowRequestObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var userFollowRequest = await jsonReader.ReadObjectAsync(stream);
                userFollowRequest.Should().BeNull();
            }
        }
    }
}
