namespace TraktApiSharp.Tests.Objects.Post.Comments.Responses.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Comments.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Comments.Responses.JsonReader")]
    public partial class CommentPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_13()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_14()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_15()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_16()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_17()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_18()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_19()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_20()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_21()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_22()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_23()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_23))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Incomplete_24()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_24))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_9()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_10()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_11()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_12()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_13()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktCommentPostResponse.Should().BeNull();
        }

        [Fact]
        public async Task Test_CommentPostResponseObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new CommentPostResponseObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktCommentPostResponse = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktCommentPostResponse.Should().BeNull();
            }
        }
    }
}
