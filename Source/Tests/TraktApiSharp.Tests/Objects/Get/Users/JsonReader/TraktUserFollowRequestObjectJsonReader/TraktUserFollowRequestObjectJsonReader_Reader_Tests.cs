namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserFollowRequestObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(12345U);
                userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(12345U);
                userFollowRequest.RequestedAt.Should().BeNull();
                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(0U);
                userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(12345U);
                userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);

                userFollowRequest.Should().NotBeNull();
                userFollowRequest.Id.Should().Be(0U);
                userFollowRequest.RequestedAt.Should().BeNull();
                userFollowRequest.User.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            var userFollowRequest = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userFollowRequest.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserFollowRequestObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktUserFollowRequestObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userFollowRequest = await traktJsonReader.ReadObjectAsync(jsonReader);
                userFollowRequest.Should().BeNull();
            }
        }
    }
}
