﻿namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktUserLikeItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_COMPLETE);

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

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_INCOMPLETE_3);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
            traktUserLikeItem.Comment.Should().BeNull();

            traktUserLikeItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_INCOMPLETE_4);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().BeNull();
            traktUserLikeItem.Comment.Should().BeNull();

            traktUserLikeItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_INCOMPLETE_5);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().BeNull();
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
            traktUserLikeItem.Comment.Should().BeNull();

            traktUserLikeItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_INCOMPLETE_6);

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

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_NOT_VALID_3);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().Be(DateTime.Parse("2015-03-30T23:18:42.000Z").ToUniversalTime());
            traktUserLikeItem.Type.Should().Be(TraktUserLikeType.Comment);
            traktUserLikeItem.Comment.Should().BeNull();

            traktUserLikeItem.List.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserLikeItemObjectJsonReader_Comment_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktUserLikeItemObjectJsonReader();

            var traktUserLikeItem = await jsonReader.ReadObjectAsync(TYPE_COMMENT_JSON_NOT_VALID_4);

            traktUserLikeItem.Should().NotBeNull();
            traktUserLikeItem.LikedAt.Should().BeNull();
            traktUserLikeItem.Type.Should().BeNull();
            traktUserLikeItem.Comment.Should().BeNull();
            traktUserLikeItem.List.Should().BeNull();
        }
    }
}
