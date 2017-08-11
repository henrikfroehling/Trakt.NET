namespace TraktApiSharp.Tests.Objects.Post.Users.Responses.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.JsonReader")]
    public partial class TraktUserFollowUserPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserFollowUserPostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktUserFollowUserPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowUserPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktUserFollowUserPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktUserFollowUserPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowUserPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktUserFollowUserPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktUserFollowUserPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowUserPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollowUserPostResponse.Should().NotBeNull();

                userFollowUserPostResponse.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());

                userFollowUserPostResponse.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserFollowUserPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktUserFollowUserPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowUserPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_TraktUserFollowUserPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktUserFollowUserPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowUserPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollowUserPostResponse.Should().NotBeNull();

                userFollowUserPostResponse.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());

                userFollowUserPostResponse.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserFollowUserPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktUserFollowUserPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowUserPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollowUserPostResponse.Should().NotBeNull();

                userFollowUserPostResponse.ApprovedAt.Should().BeNull();
                userFollowUserPostResponse.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserFollowUserPostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktUserFollowUserPostResponseObjectJsonReader();

            var userFollowUserPostResponse = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userFollowUserPostResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserFollowUserPostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktUserFollowUserPostResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowUserPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                userFollowUserPostResponse.Should().BeNull();
            }
        }
    }
}
