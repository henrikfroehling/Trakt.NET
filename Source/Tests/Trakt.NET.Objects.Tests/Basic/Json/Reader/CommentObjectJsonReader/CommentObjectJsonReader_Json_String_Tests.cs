namespace TraktNet.Objects.Tests.Basic.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Basic.Json.Reader;
    using Xunit;

    [Category("Objects.Basic.JsonReader")]
    public partial class CommentObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_13()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_13);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_14()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_14);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_15()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_15);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_16()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_16);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_17()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_17);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_18()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_18);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_19()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_19);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_20()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_20);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_21()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_21);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Incomplete_22()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_22);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_8()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_8);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_9()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_9);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_10()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_10);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().NotBeNull();
            traktComment.User.Username.Should().Be("sean");
            traktComment.User.IsPrivate.Should().BeFalse();
            traktComment.User.Name.Should().Be("Sean Rudford");
            traktComment.User.IsVIP.Should().BeTrue();
            traktComment.User.IsVIP_EP.Should().BeTrue();
            traktComment.User.Ids.Should().NotBeNull();
            traktComment.User.Ids.Slug.Should().Be("sean");
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_11()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_11);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(76957U);
            traktComment.ParentId.Should().Be(1234U);
            traktComment.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
            traktComment.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
            traktComment.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().Be(1);
            traktComment.Likes.Should().Be(2);
            traktComment.UserRating.Should().Be(7.3f);
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Not_Valid_12()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_12);

            traktComment.Should().NotBeNull();
            traktComment.Id.Should().Be(0U);
            traktComment.ParentId.Should().BeNull();
            traktComment.CreatedAt.Should().Be(default(DateTime));
            traktComment.UpdatedAt.Should().BeNull();
            traktComment.Comment.Should().BeNull();
            traktComment.Spoiler.Should().BeFalse();
            traktComment.Review.Should().BeFalse();
            traktComment.Replies.Should().BeNull();
            traktComment.Likes.Should().BeNull();
            traktComment.UserRating.Should().BeNull();
            traktComment.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(default(string));
            traktComment.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new CommentObjectJsonReader();

            var traktComment = await jsonReader.ReadObjectAsync(string.Empty);
            traktComment.Should().BeNull();
        }
    }
}
