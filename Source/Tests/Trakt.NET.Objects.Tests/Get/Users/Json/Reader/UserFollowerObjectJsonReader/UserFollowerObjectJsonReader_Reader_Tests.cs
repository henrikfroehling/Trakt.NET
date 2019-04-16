﻿namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
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
    public partial class UserFollowerObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserFollowerObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollower = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserFollowerObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollower = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserFollowerObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollower = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollower.Should().NotBeNull();
                userFollower.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                userFollower.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserFollowerObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollower = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserFollowerObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollower = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollower.Should().NotBeNull();
                userFollower.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                userFollower.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserFollowerObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollower = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollower.Should().NotBeNull();
                userFollower.FollowedAt.Should().BeNull();
                userFollower.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserFollowerObjectJsonReader();

            var userFollower = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userFollower.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserFollowerObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserFollowerObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollower = await traktJsonReader.ReadObjectAsync(jsonReader);
                userFollower.Should().BeNull();
            }
        }
    }
}
