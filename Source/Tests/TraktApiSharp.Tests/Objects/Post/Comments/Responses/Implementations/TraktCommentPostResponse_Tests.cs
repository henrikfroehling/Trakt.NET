namespace TraktApiSharp.Tests.Objects.Post.Comments.Responses.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using TraktApiSharp.Objects.Post.Comments.Responses.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Comments.Responses.Implementations")]
    public class TraktCommentPostResponse_Tests
    {
        [Fact]
        public void Test_TraktCommentPostResponse_Default_Constructor()
        {
            var traktCommentPostResponse = new TraktCommentPostResponse();

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

        [Fact]
        public async Task Test_TraktMovieCheckinPostResponse_From_Json()
        {
            var jsonReader = new CommentPostResponseObjectJsonReader();
            var traktCommentPostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktCommentPostResponse;

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

        private const string JSON =
            @"{
                ""id"": 76957,
                ""parent_id"": 1234,
                ""created_at"": ""2016-04-01T12:44:40Z"",
                ""updated_at"": ""2016-04-03T08:23:38Z"",
                ""comment"": ""I hate they made The flash a kids show. Could else be much better. And with a better flash offcourse."",
                ""spoiler"": false,
                ""review"": false,
                ""replies"": 1,
                ""likes"": 2,
                ""user_rating"": 7.3,
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean""
                  }
                },
                ""sharing"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                }
              }";
    }
}
