namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
                traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
                traktUserLikeItem.Comment.Should().NotBeNull();
                traktUserLikeItem.Comment.Id.Should().Be(76957U);
                traktUserLikeItem.Comment.ParentId.Should().Be(1234U);
                traktUserLikeItem.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktUserLikeItem.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktUserLikeItem.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktUserLikeItem.Comment.Spoiler.Should().BeFalse();
                traktUserLikeItem.Comment.Review.Should().BeFalse();
                traktUserLikeItem.Comment.Replies.Should().Be(1);
                traktUserLikeItem.Comment.Likes.Should().Be(2);
                traktUserLikeItem.Comment.UserRating.Should().Be(7.3f);
                traktUserLikeItem.Comment.User.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Username.Should().Be("sean");
                traktUserLikeItem.Comment.User.IsPrivate.Should().BeFalse();
                traktUserLikeItem.Comment.User.Name.Should().Be("Sean Rudford");
                traktUserLikeItem.Comment.User.IsVIP.Should().BeTrue();
                traktUserLikeItem.Comment.User.IsVIP_EP.Should().BeTrue();
                traktUserLikeItem.Comment.User.Ids.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Ids.Slug.Should().Be("sean");

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().BeNull();
                traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
                traktUserLikeItem.Comment.Should().NotBeNull();
                traktUserLikeItem.Comment.Id.Should().Be(76957U);
                traktUserLikeItem.Comment.ParentId.Should().Be(1234U);
                traktUserLikeItem.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktUserLikeItem.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktUserLikeItem.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktUserLikeItem.Comment.Spoiler.Should().BeFalse();
                traktUserLikeItem.Comment.Review.Should().BeFalse();
                traktUserLikeItem.Comment.Replies.Should().Be(1);
                traktUserLikeItem.Comment.Likes.Should().Be(2);
                traktUserLikeItem.Comment.UserRating.Should().Be(7.3f);
                traktUserLikeItem.Comment.User.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Username.Should().Be("sean");
                traktUserLikeItem.Comment.User.IsPrivate.Should().BeFalse();
                traktUserLikeItem.Comment.User.Name.Should().Be("Sean Rudford");
                traktUserLikeItem.Comment.User.IsVIP.Should().BeTrue();
                traktUserLikeItem.Comment.User.IsVIP_EP.Should().BeTrue();
                traktUserLikeItem.Comment.User.Ids.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Ids.Slug.Should().Be("sean");

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
                traktUserLikeItem.Type.Should().BeNull();
                traktUserLikeItem.Comment.Should().NotBeNull();
                traktUserLikeItem.Comment.Id.Should().Be(76957U);
                traktUserLikeItem.Comment.ParentId.Should().Be(1234U);
                traktUserLikeItem.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktUserLikeItem.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktUserLikeItem.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktUserLikeItem.Comment.Spoiler.Should().BeFalse();
                traktUserLikeItem.Comment.Review.Should().BeFalse();
                traktUserLikeItem.Comment.Replies.Should().Be(1);
                traktUserLikeItem.Comment.Likes.Should().Be(2);
                traktUserLikeItem.Comment.UserRating.Should().Be(7.3f);
                traktUserLikeItem.Comment.User.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Username.Should().Be("sean");
                traktUserLikeItem.Comment.User.IsPrivate.Should().BeFalse();
                traktUserLikeItem.Comment.User.Name.Should().Be("Sean Rudford");
                traktUserLikeItem.Comment.User.IsVIP.Should().BeTrue();
                traktUserLikeItem.Comment.User.IsVIP_EP.Should().BeTrue();
                traktUserLikeItem.Comment.User.Ids.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Ids.Slug.Should().Be("sean");

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
                traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
                traktUserLikeItem.Comment.Should().BeNull();

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
                traktUserLikeItem.Type.Should().BeNull();
                traktUserLikeItem.Comment.Should().BeNull();

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().BeNull();
                traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
                traktUserLikeItem.Comment.Should().BeNull();

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().BeNull();
                traktUserLikeItem.Type.Should().BeNull();
                traktUserLikeItem.Comment.Should().NotBeNull();
                traktUserLikeItem.Comment.Id.Should().Be(76957U);
                traktUserLikeItem.Comment.ParentId.Should().Be(1234U);
                traktUserLikeItem.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktUserLikeItem.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktUserLikeItem.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktUserLikeItem.Comment.Spoiler.Should().BeFalse();
                traktUserLikeItem.Comment.Review.Should().BeFalse();
                traktUserLikeItem.Comment.Replies.Should().Be(1);
                traktUserLikeItem.Comment.Likes.Should().Be(2);
                traktUserLikeItem.Comment.UserRating.Should().Be(7.3f);
                traktUserLikeItem.Comment.User.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Username.Should().Be("sean");
                traktUserLikeItem.Comment.User.IsPrivate.Should().BeFalse();
                traktUserLikeItem.Comment.User.Name.Should().Be("Sean Rudford");
                traktUserLikeItem.Comment.User.IsVIP.Should().BeTrue();
                traktUserLikeItem.Comment.User.IsVIP_EP.Should().BeTrue();
                traktUserLikeItem.Comment.User.Ids.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Ids.Slug.Should().Be("sean");

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().BeNull();
                traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
                traktUserLikeItem.Comment.Should().NotBeNull();
                traktUserLikeItem.Comment.Id.Should().Be(76957U);
                traktUserLikeItem.Comment.ParentId.Should().Be(1234U);
                traktUserLikeItem.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktUserLikeItem.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktUserLikeItem.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktUserLikeItem.Comment.Spoiler.Should().BeFalse();
                traktUserLikeItem.Comment.Review.Should().BeFalse();
                traktUserLikeItem.Comment.Replies.Should().Be(1);
                traktUserLikeItem.Comment.Likes.Should().Be(2);
                traktUserLikeItem.Comment.UserRating.Should().Be(7.3f);
                traktUserLikeItem.Comment.User.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Username.Should().Be("sean");
                traktUserLikeItem.Comment.User.IsPrivate.Should().BeFalse();
                traktUserLikeItem.Comment.User.Name.Should().Be("Sean Rudford");
                traktUserLikeItem.Comment.User.IsVIP.Should().BeTrue();
                traktUserLikeItem.Comment.User.IsVIP_EP.Should().BeTrue();
                traktUserLikeItem.Comment.User.Ids.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Ids.Slug.Should().Be("sean");

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
                traktUserLikeItem.Type.Should().BeNull();
                traktUserLikeItem.Comment.Should().NotBeNull();
                traktUserLikeItem.Comment.Id.Should().Be(76957U);
                traktUserLikeItem.Comment.ParentId.Should().Be(1234U);
                traktUserLikeItem.Comment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktUserLikeItem.Comment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktUserLikeItem.Comment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktUserLikeItem.Comment.Spoiler.Should().BeFalse();
                traktUserLikeItem.Comment.Review.Should().BeFalse();
                traktUserLikeItem.Comment.Replies.Should().Be(1);
                traktUserLikeItem.Comment.Likes.Should().Be(2);
                traktUserLikeItem.Comment.UserRating.Should().Be(7.3f);
                traktUserLikeItem.Comment.User.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Username.Should().Be("sean");
                traktUserLikeItem.Comment.User.IsPrivate.Should().BeFalse();
                traktUserLikeItem.Comment.User.Name.Should().Be("Sean Rudford");
                traktUserLikeItem.Comment.User.IsVIP.Should().BeTrue();
                traktUserLikeItem.Comment.User.IsVIP_EP.Should().BeTrue();
                traktUserLikeItem.Comment.User.Ids.Should().NotBeNull();
                traktUserLikeItem.Comment.User.Ids.Slug.Should().Be("sean");

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
                traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
                traktUserLikeItem.Comment.Should().BeNull();

                traktUserLikeItem.List.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserLikeItemObjectJsonReader_Comment_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserLikeItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_COMMENT_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserLikeItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserLikeItem.Should().NotBeNull();
                traktUserLikeItem.LikedAt.Should().BeNull();
                traktUserLikeItem.Type.Should().BeNull();
                traktUserLikeItem.Comment.Should().BeNull();
                traktUserLikeItem.List.Should().BeNull();
            }
        }
    }
}
