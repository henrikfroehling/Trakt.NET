namespace TraktApiSharp.Tests.Objects.Post.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktShowCommentPostTests
    {
        [TestMethod]
        public void TestTraktShowCommentPostDefaultConstructor()
        {
            var showComment = new TraktShowCommentPost();

            showComment.Comment.Should().BeNullOrEmpty();
            showComment.Spoiler.Should().NotHaveValue();
            showComment.Sharing.Should().BeNull();
            showComment.Show.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowCommentPostWriteJson()
        {
            var comment = "this is a comment";
            var spoiler = true;
            var sharing = new TraktSharing { Facebook = false, Twitter = false, Tumblr = true };

            var showTitle = "Breaking Bad";
            var showTraktId = 1U;
            var showSlug = "breaking-bad";

            var show = new TraktShow
            {
                Title = showTitle,
                Ids = new TraktShowIds { Trakt = showTraktId, Slug = showSlug }
            };

            var showComment = new TraktShowCommentPost
            {
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing,
                Show = show
            };

            var strJson = JsonConvert.SerializeObject(showComment);

            strJson.Should().NotBeNullOrEmpty();

            var showCommentFromJson = JsonConvert.DeserializeObject<TraktShowCommentPost>(strJson);

            showCommentFromJson.Should().NotBeNull();
            showCommentFromJson.Comment.Should().Be(comment);
            showCommentFromJson.Spoiler.Should().Be(spoiler);
            showCommentFromJson.Sharing.Should().NotBeNull();
            showCommentFromJson.Sharing.Facebook.Should().BeFalse();
            showCommentFromJson.Sharing.Twitter.Should().BeFalse();
            showCommentFromJson.Sharing.Tumblr.Should().BeTrue();

            showCommentFromJson.Show.Should().NotBeNull();
            showCommentFromJson.Show.Title.Should().Be(showTitle);
            showCommentFromJson.Show.Ids.Should().NotBeNull();
            showCommentFromJson.Show.Ids.Trakt.Should().Be(showTraktId);
            showCommentFromJson.Show.Ids.Slug.Should().Be(showSlug);
        }
    }
}
