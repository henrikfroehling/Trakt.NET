namespace TraktApiSharp.Tests.Objects.Post.Comments.Responses
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Post.Comments.Responses;
    using Utils;

    [TestClass]
    public class TraktCommentPostResponseTests
    {
        [TestMethod]
        public void TestTraktCommentPostResponseDefaultConstructor()
        {
            var commentPostResponse = new TraktCommentPostResponse();

            commentPostResponse.Id.Should().Be(0);
            commentPostResponse.ParentId.Should().BeNull();
            commentPostResponse.CreatedAt.Should().Be(DateTime.MinValue);
            commentPostResponse.Comment.Should().BeNullOrEmpty();
            commentPostResponse.Spoiler.Should().BeFalse();
            commentPostResponse.Review.Should().BeFalse();
            commentPostResponse.Replies.Should().NotHaveValue();
            commentPostResponse.Likes.Should().NotHaveValue();
            commentPostResponse.UserRating.Should().NotHaveValue();
            commentPostResponse.User.Should().BeNull();
            commentPostResponse.Sharing.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktCommentPostResponseReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Post\Comments\Responses\CommentPostResponse.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var commentPostResponse = JsonConvert.DeserializeObject<TraktCommentPostResponse>(jsonFile);

            commentPostResponse.Should().NotBeNull();
            commentPostResponse.Id.Should().Be(190U);
            commentPostResponse.ParentId.Should().Be(0U);
            commentPostResponse.CreatedAt.Should().Be(DateTime.Parse("2014-08-04T06:46:01.996Z").ToUniversalTime());
            commentPostResponse.Comment.Should().Be("Oh, I wasn't really listening.");
            commentPostResponse.Spoiler.Should().BeFalse();
            commentPostResponse.Review.Should().BeFalse();
            commentPostResponse.Replies.Should().Be(0);
            commentPostResponse.Likes.Should().Be(0);
            commentPostResponse.UserRating.Should().NotHaveValue();
            commentPostResponse.User.Should().NotBeNull();
            commentPostResponse.User.Username.Should().Be("sean");
            commentPostResponse.User.Private.Should().BeFalse();
            commentPostResponse.User.Name.Should().Be("Sean Rudford");
            commentPostResponse.User.VIP.Should().BeTrue();
            commentPostResponse.User.VIP_EP.Should().BeFalse();
            commentPostResponse.Sharing.Should().NotBeNull();
            commentPostResponse.Sharing.Facebook.Should().BeTrue();
            commentPostResponse.Sharing.Twitter.Should().BeTrue();
            commentPostResponse.Sharing.Tumblr.Should().BeFalse();
            commentPostResponse.Sharing.Medium.Should().BeTrue();
        }
    }
}
