namespace TraktNet.Tests.Objects.Post.Comments.Responses.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Post.Comments.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Comments.Responses.JsonReader")]
    public partial class CommentPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_15()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_15.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_16()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_16.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_17()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_17.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_18()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_18.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_19()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_19.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_20()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_20.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_21()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_21.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_22()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_22.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_23()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_23.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Incomplete_24()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_24.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_9()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_9.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_10()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_10.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_11()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_11.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().NotBeNull();
                traktCommentPostResponse.Sharing.Facebook.Should().BeTrue();
                traktCommentPostResponse.Sharing.Twitter.Should().BeTrue();
                traktCommentPostResponse.Sharing.Google.Should().BeTrue();
                traktCommentPostResponse.Sharing.Tumblr.Should().BeTrue();
                traktCommentPostResponse.Sharing.Medium.Should().BeTrue();
                traktCommentPostResponse.Sharing.Slack.Should().BeTrue();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_12()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_12.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(76957U);
                traktCommentPostResponse.ParentId.Should().Be(1234U);
                traktCommentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2016-04-01T12:44:40Z").ToUniversalTime());
                traktCommentPostResponse.UpdatedAt.Should().Be(DateTime.Parse("2016-04-03T08:23:38Z").ToUniversalTime());
                traktCommentPostResponse.Comment.Should().Be("I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse.");
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().Be(1);
                traktCommentPostResponse.Likes.Should().Be(2);
                traktCommentPostResponse.UserRating.Should().Be(7.3f);
                traktCommentPostResponse.User.Should().NotBeNull();
                traktCommentPostResponse.User.Username.Should().Be("sean");
                traktCommentPostResponse.User.IsPrivate.Should().BeFalse();
                traktCommentPostResponse.User.Name.Should().Be("Sean Rudford");
                traktCommentPostResponse.User.IsVIP.Should().BeTrue();
                traktCommentPostResponse.User.IsVIP_EP.Should().BeTrue();
                traktCommentPostResponse.User.Ids.Should().NotBeNull();
                traktCommentPostResponse.User.Ids.Slug.Should().Be("sean");
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Not_Valid_13()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = JSON_NOT_VALID_13.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);

                traktCommentPostResponse.Should().NotBeNull();
                traktCommentPostResponse.Id.Should().Be(0U);
                traktCommentPostResponse.ParentId.Should().BeNull();
                traktCommentPostResponse.CreatedAt.Should().Be(default(DateTime));
                traktCommentPostResponse.UpdatedAt.Should().BeNull();
                traktCommentPostResponse.Comment.Should().BeNull();
                traktCommentPostResponse.Spoiler.Should().BeFalse();
                traktCommentPostResponse.Review.Should().BeFalse();
                traktCommentPostResponse.Replies.Should().BeNull();
                traktCommentPostResponse.Likes.Should().BeNull();
                traktCommentPostResponse.UserRating.Should().BeNull();
                traktCommentPostResponse.User.Should().BeNull();
                traktCommentPostResponse.Sharing.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            var traktCommentPostResponse = await jsonReader.ReadObjectAsync(default(Stream));
            traktCommentPostResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktCommentPostResponse = await jsonReader.ReadObjectAsync(stream);
                traktCommentPostResponse.Should().BeNull();
            }
        }
    }
}
