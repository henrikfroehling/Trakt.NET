namespace TraktApiSharp.Tests.Objects.Post.Comments
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Objects.Post.Comments;

    [TestClass]
    public class TraktEpisodeCommentPostTests
    {
        [TestMethod]
        public void TestTraktEpisodeCommentPostDefaultConstructor()
        {
            var episodeComment = new TraktEpisodeCommentPost();

            episodeComment.Comment.Should().BeNullOrEmpty();
            episodeComment.Spoiler.Should().NotHaveValue();
            episodeComment.Sharing.Should().BeNull();
            episodeComment.Episode.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktEpisodeCommentPostWriteJson()
        {
            var comment = "this is a comment";
            var spoiler = false;
            var sharing = new TraktSharing { Facebook = true, Twitter = false, Tumblr = true };

            var episodeTraktId = 16U;

            var episode = new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = episodeTraktId } };

            var episodeComment = new TraktEpisodeCommentPost
            {
                Comment = comment,
                Spoiler = spoiler,
                Sharing = sharing,
                Episode = episode
            };

            var strJson = JsonConvert.SerializeObject(episodeComment);

            strJson.Should().NotBeNullOrEmpty();

            var episodeCommentFromJson = JsonConvert.DeserializeObject<TraktEpisodeCommentPost>(strJson);

            episodeCommentFromJson.Should().NotBeNull();
            episodeCommentFromJson.Comment.Should().Be(comment);
            episodeCommentFromJson.Spoiler.Should().Be(spoiler);
            episodeCommentFromJson.Sharing.Should().NotBeNull();
            episodeCommentFromJson.Sharing.Facebook.Should().BeTrue();
            episodeCommentFromJson.Sharing.Twitter.Should().BeFalse();
            episodeCommentFromJson.Sharing.Tumblr.Should().BeTrue();

            episodeCommentFromJson.Episode.Should().NotBeNull();
            episodeCommentFromJson.Episode.Ids.Should().NotBeNull();
            episodeCommentFromJson.Episode.Ids.Trakt.Should().Be(episodeTraktId);
        }
    }
}
